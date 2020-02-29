import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const Home = () => import(/* webpackChunkName: "Home" */ './components/Home.vue');
const ViewBook = () => import(/* webpackChunkName: "Book" */ './components/EditBook.vue');
const AddBook = () => import(/* webpackChunkName: "Book" */ './components/AddBook.vue');

const router = new VueRouter({
  routes: [
    { path: '/', component: Home },
    {
      name: 'book_view',
      path: '/book/:id',
      component: ViewBook,
      props: true
        },
        {
            name: 'book_add',
            path: '/addbook/:id',
            component: AddBook,
            props: true
        }
  ]
});

export default router;