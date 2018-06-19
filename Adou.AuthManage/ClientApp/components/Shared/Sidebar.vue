<template>
    <aside class="sidebar">
        {{message}}
    </aside>
</template>

<script>
export default {
  name: "SidebarComponent",
    data() {
    return {
      message: "sidebar"
    };
  }
}
</script>