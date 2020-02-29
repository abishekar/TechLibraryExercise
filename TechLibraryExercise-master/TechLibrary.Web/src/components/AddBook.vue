<template>
   <!--<div v-if="book">-->
    <div>
        <br />
        <b-card-text>
            <h3> Add New Book</h3>  
        </b-card-text>
        <br />
        <b-button to="/" variant="primary">Back</b-button>
        <br/>
        <br/>
        <b-form @submit="onSubmit" @reset="onReset" v-if="show">

            <b-form-group id="input-group-1a"
                          label="Title:"
                          label-for="input-1a"
                          description="Book title">
                <b-form-textarea id="input-1aa"
                                 v-model="book.title"
                                 rows="1"
                                 placeholder="Enter Title"></b-form-textarea>
            </b-form-group>

            <b-form-group id="input-group-1s"
                          label="ISBN:"
                          label-for="input-1s"
                          description="ISBN #">
                <b-form-textarea id="input-1ss"
                                 v-model="book.iSBN"
                                 rows="1"
                                 placeholder="Enter ISBN"></b-form-textarea>
            </b-form-group>

            <b-form-group id="input-group-1d"
                          label="Published Date:"
                          label-for="input-1d"
                          description="Published Date">
                <b-form-textarea id="input-1dd"
                                 v-model="book.publishedDate"
                                 rows="1"
                                 placeholder="Enter Published Date"></b-form-textarea>
            </b-form-group>



            <b-form-group id="input-group-1f"
                          label="Thumbnail URL:"
                          label-for="input-1f"
                          description="Book Thumbnail Url">
                <b-form-textarea id="input-1ff"
                                 v-model="book.thumbnailUrl"
                                 rows="1"
                                 placeholder="Enter Thumbnail Url"></b-form-textarea>
            </b-form-group>

            <b-form-group id="input-group-1g"
                          label="Short Description:"
                          label-for="input-1g"
                          description="Book short description">
                <b-form-textarea id="input-1gg"
                                 v-model="book.shortDescr"
                                 rows="3"
                                 placeholder="Enter Short Description"></b-form-textarea>
            </b-form-group>
            <b-form-group id="input-group-1h"
                          label="Long Description:"
                          label-for="input-1h"
                          description="Book long description">
                <b-form-textarea id="input-1hh"
                                 v-model="book.longDescr"
                                 rows="7"
                                 placeholder="Enter Long Description"></b-form-textarea>
            </b-form-group>
            <b-button type="submit" variant="primary">Submit</b-button>
            &nbsp; &nbsp;
            <b-button type="reset" variant="danger">Reset</b-button>
        </b-form>

    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'Book',
        props: ["id"],
        data: () => ({
            book: {
             "bookId": 0,
              "title": "",
               "iSBN": "",
                "publishedDate": "",
                "thumbnailUrl": "",
                "shortDescr": "",
                "longDescr": "",
                "rowVersion": ""

            },
            show: true
        }),
        mounted() {
            this.book = {
             "bookId": 0,
              "title": "",
               "iSBN": "",
                "publishedDate": "",
                "thumbnailUrl": "",
                "shortDescr": "",
                "longDescr": "",
                "rowVersion": ""

            };
        },
        methods
            : {
            onSubmit(evt) {
                evt.preventDefault()
           
                     axios.post("https://localhost:5001/books/BookUpsert"
                    , {
                        'book': this.book,
                    }
                )
                    .then(res => {
                        this.book = res.data.results;
                        alert('Book Added Successfuly!');
                        return res.data.results;
                        
        })
       
            },
            onReset(evt) {
                evt.preventDefault()
                // Reset our form values
                 this.book = {
             "bookId": 0,
              "title": "",
               "iSBN": "",
                "publishedDate": "",
                "thumbnailUrl": "",
                "shortDescr": "",
                     "longDescr": "",
                "rowVersion": ""

            };

                // Trick to reset/clear native browser form validation state
                this.show = false
                this.$nextTick(() => {
                    this.show = true
                })
            }
        }
    }
</script>