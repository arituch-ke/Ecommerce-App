<script setup>
import ProductCard from './components/ProductCard.vue';
import { onMounted, reactive } from 'vue';
import httpClient from './utils/httpClient';

const products = reactive([]);

const fetchProducts = async () => {
  const response = await httpClient.get('/products');
  products.push(...response.data.products)
};

onMounted(async () => {
  await fetchProducts();
});
</script>

<template>
  <v-app>
    <v-main class="bg-write-lighten-3">
      <v-container>
        <v-row>
          <v-col cols="12">
            <h1 class="text-center">Explore Best Selling</h1>
            <h3 class="text-center text-grey">Offer up to 50% off</h3>
          </v-col>
          <v-col v-for="product in products" :key="product.id" cols="12" md="3">
            <ProductCard :product="product" />
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>