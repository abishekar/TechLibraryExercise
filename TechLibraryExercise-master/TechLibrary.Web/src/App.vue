<template>

    <div id="app">
        <b-container>
            <router-view>
            
            </router-view>
        </b-container>
    </div>

</template>

<script>
    import Home from './components/Home.vue';

    export default {
        name: 'app',
        components: {
            Home
        }
    };
</script>

<style>
</style>

