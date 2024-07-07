<script setup>
import { defineProps, defineEmits, watch, ref, computed } from 'vue';

const props = defineProps({
  product: {
    type: Object,
    required: true
  },
  dialog: {
    type: Boolean,
    required: true
  }
});

const emit = defineEmits(['closeDialog']);
const selection = ref(0);
const localDialog = ref(props.dialog);

watch(() => props.dialog, (newVal) => {
  localDialog.value = newVal;
});

const originalPrice = computed(() => {
  return parseFloat(props.product.originalPrice).toFixed(2);
})
const discountedPrice = computed(() => {
  return parseFloat(props.product.discountedPrice).toFixed(2);
})
</script>

<template>
  <div class="text-center pa-4">
    <v-dialog v-model="localDialog" max-width="800" persistent>
      <v-card>
        <v-row>
          <v-col cols="12" md="6">
            <v-img height="300" class="ma-5" :src="props.product.imageUrl" cover />
          </v-col>
          <v-col cols="12" md="6">
            <v-card-title>{{ props.product.name }}</v-card-title>
            <v-card-subtitle>
              <span class="me-1">{{ props.product.category }}</span>
            </v-card-subtitle>
            <v-card-text>
              <div class="mb-2">
                <span>
                  Availability:
                  <b v-if="props.product.availability" class="text-green"> In Stock</b>
                  <b v-else class="text-red">Out of Stock</b>
                </span>
              </div>
              <div class="mb-2">
                <span>Vendor: <b>{{ props.product.vendor }}</b></span>
              </div>

              <div class="mb-2 d-flex align-center">
                <div style="margin-right: 10px;">SKU:</div>
                <div>
                  <b v-if="Array(props.product.skUs).length <= 0 || !props.product.skUs">N/A</b>
                  <v-chip-group v-else v-model="selection" selected-class="bg-deep-purple-lighten-2">
                    <v-chip size="small" v-for="sku in props.product.skUs" :key="sku.code">{{ sku.code }}</v-chip>
                  </v-chip-group>
                </div>
              </div>

              <div v-if="discountedPrice <= 0" class="my-4 text-subtitle-1 text-orange">
                <h2>${{ originalPrice }}</h2>
              </div>
              <div v-else class="my-4 text-subtitle-1">
                <h2>
                  <span class="discounted text-grey mr-2">${{ originalPrice }}</span>
                  <span class="text-orange">${{ discountedPrice }}</span>
                </h2>
              </div>
            </v-card-text>
          </v-col>
        </v-row>
        <v-card-actions>
          <v-btn text @click="emit('closeDialog')">Close</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>