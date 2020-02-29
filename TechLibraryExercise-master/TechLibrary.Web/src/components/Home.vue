<template>
    <div class="home">
        <h1>Vue.Js</h1>
        <br/>
        <template>
            <div>
                <b-form-group id="input-group-1"
                              label="Title:"
                              label-for="input-1"
                              description="Book Title">
                    <b-form-input id="input-1"
                                  v-model="title"
                                  rows="1"
                                  ></b-form-input>
                </b-form-group>
               
                <!--<div class="mt-2"> {{ title }}</div>-->
            </div>
            
            <div>
                <b-form-group id="input-group-11"
                              label="Description:"
                              label-for="input-11"
                              description="Book Description">
                    <b-form-input id="input-10"
                                  v-model="description"
                                  rows="1"
                                  ></b-form-input>
                </b-form-group>
                <!--<div class="mt-2"> {{ description }}</div>-->
            </div>
            
            <div>
                <!--<b-form-input v-model="pageSize" placeholder="Enter Page Size"></b-form-input>-->

                <b-form-group id="input-group-1a"
                              label="Page Size:"
                              label-for="input-1a"
                              description="Page Size">
                    <b-form-input id="input-122" itemtype="number"
                                     v-model="pageSize"
                                     rows="1"
                                     ></b-form-input>
                </b-form-group>

              
            </div>
        </template>
        <br/>
        <br/>

        <div>
            <b-button v-on:click="SearchBooks" variant="success">Search</b-button>
            &nbsp; &nbsp; &nbsp; &nbsp;
            <b-button variant="warning" v-on:click="ClearSearchFilter">Clear</b-button>
        </div>
        <br/>
        <br/>

        <b-pagination v-model="currentPage"
                      :total-rows="totalItems"
                      :per-page="pageSize"
                      aria-controls="books-table"></b-pagination>

        <div>
            <b-button  variant="primary" :to="{ name: 'book_add', params: { 'id' : 0 } }">Add Book</b-button>
            &nbsp;
        </div>
        <br/>

        <b-table id="books-table" striped hover :items="items" :fields="fields" responsive="sm" :current-page="currentPage" :per-page="0">
            <template v-slot:cell(thumbnailUrl)="data">
                <b-img :src="data.value" thumbnail fluid></b-img>
            </template>
            <template v-slot:cell(title_link)="data">
                <b-link :to="{ name: 'book_view', params: { 'id' : data.item.bookId } }">{{ data.item.title }}</b-link>
            </template>
        </b-table>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'Home',
        //props: {
        //},
        data: () => ({
            fields: [
                { key: 'thumbnailUrl', label: 'Book Image' },
                { key: 'title_link', label: 'Book Title', sortable: true, sortDirection: 'desc' },
                { key: 'isbn', label: 'ISBN', sortable: true, sortDirection: 'desc' },
                  { key: 'publishedDate', label: 'Published Date', sortable: true, sortDirection: 'desc' },
                { key: 'shortDescr', label: 'Short Description', sortable: true, sortDirection: 'desc' }
               

            ],
            items: [],
            pageSize: 10,
            totalItems: 0,
            currentPage: 1,
             title: "",
            description: ""
            

        }),
    //    mounted() {

    //this.SearchBooks().catch(error => {
    //  this.Console.error(error)
    //})
    //    },

        mounted() {
            try {
                this.SearchBooks()
            }
            catch (ex) {
                this.Console.error(ex)
            }
        },

        methods: {
            SearchBooks() {
                 axios.post("https://localhost:5001/books/BookSearch"
                    , {
                        'title': this.title,
                        'description': this.description,
                        'pageNumber': this.currentPage,
                        'pageSize': parseInt(this.pageSize)
                    }
                )
                    .then(res => {
                        this.totalItems = res.data["rowCount"]
                        this.currentPage = res.data["currentPage"]
                        this.items = res.data.results
                        return res.data.results;
        })
        .then(items => items)
            },
            ClearSearchFilter() {
                this.title = "";
                this.description = "";
                this.pageSize = 10;
            }
        },
        
  watch: {
    currentPage: {
      handler: function() {
        try {
                this.SearchBooks()
            }
            catch (ex) {
                this.Console.error(ex)
            }
      }
    }
  }
    }

    </script>


 

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>

