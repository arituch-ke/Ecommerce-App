import { fileURLToPath, URL } from "node:url";

import { defineConfig } from "vite";
import Components from "unplugin-vue-components/vite";
import plugin from "@vitejs/plugin-vue";
import fs from "fs";
import path from "path";
import child_process from "child_process";
import { env } from "process";
import Vuetify, { transformAssetUrls } from "vite-plugin-vuetify";

const baseFolder =
  env.APPDATA !== undefined && env.APPDATA !== ""
    ? `${env.APPDATA}/ASP.NET/https`
    : `${env.HOME}/.aspnet/https`;

const certificateName = "ecommerce-app.client";
const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
  if (
    0 !==
    child_process.spawnSync(
      "dotnet",
      [
        "dev-certs",
        "https",
        "--export-path",
        certFilePath,
        "--format",
        "Pem",
        "--no-password",
      ],
      { stdio: "inherit" }
    ).status
  ) {
    throw new Error("Could not create certificate.");
  }
}

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    plugin({
      template: { transformAssetUrls },
    }),
    Vuetify(),
    Components(),
  ],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", import.meta.url)),
    },
    extensions: [".js", ".json", ".jsx", ".mjs", ".ts", ".tsx", ".vue"],
  },
  server: {
    proxy: {
      "^/api": {
        target: "http://localhost:5288",
        secure: false,
      },
    },
    https: {
      key: fs.readFileSync(keyFilePath),
      cert: fs.readFileSync(certFilePath),
    },
  },
});
