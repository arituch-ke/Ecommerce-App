<script setup>
import ProductDialog from './ProductDialog';
import { ref, computed, reactive } from 'vue';
import httpClient from '../utils/httpClient';

const props = defineProps({
  product: {
    type: Object,
    required: true
  }
})

const isDialogOpen = ref(false);
const product = reactive(props.product);

const readMore = async () => {
  isDialogOpen.value = true;
  const response = await httpClient.get(`/products/${props.product.id}`);
  product.availability = response.data.skUs.some(sku => sku.inStock === true) ? true : false;
  Object.assign(product, response.data);
}
const dialogClose = () => {
  isDialogOpen.value = false;
}

const originalPrice = computed(() => {
  return parseFloat(props.product.originalPrice).toFixed(2);
})
const discountedPrice = computed(() => {
  return parseFloat(props.product.discountedPrice).toFixed(2);
})
</script>
<template>
  <div>
    <ProductDialog v-if="isDialogOpen" :product="product" :dialog="isDialogOpen" @closeDialog="dialogClose" />
    <v-card variant="flat" hover max-width="374" link @click="readMore">
      <v-img height="250" :src="props.product.imageUrl" cover />

      <v-card-item>
        <v-card-title>{{ props.product.name }}</v-card-title>

        <v-card-subtitle>
          <span class="me-1">{{ props.product.category }}</span>

        </v-card-subtitle>
      </v-card-item>

      <v-card-text>
        <v-row align="center" class="mx-0">
          <v-rating :model-value="props.product.rating" color="amber" density="compact" size="small" half-increments
            readonly />
          <div class="text-grey">
            ({{ props.product.ratingCount }})
          </div>
        </v-row>

        <div v-if="discountedPrice <= 0" class="my-4 text-subtitle-1 text-orange">
          ${{ originalPrice }}
        </div>
        <div v-else class="my-4 text-subtitle-1">
          <span class="discounted text-grey mr-2">${{ originalPrice }}</span>
          <span class="text-orange">${{ discountedPrice }}</span>
        </div>
      </v-card-text>
    </v-card>
  </div>
</template>
<style>
.discounted {
  text-decoration: line-through;
}
</style>