<template>
    <header class="main-header">
        {{message}}
    </header>
</template>

<script>
export default {
  name: "HeaderComponent",
  data() {
    return {
      message: "Header"
    };
  }
};
</script>
