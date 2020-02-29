<template>
    <div v-if="book">
        <b-card :title="book.title"
                :img-src="book.thumbnailUrl"
                img-alt="Image"
                img-top
                tag="article"
                style="max-width: 30rem;"
                class="mb-2">
            <b-card-text>
                {{ book.descr }}
            </b-card-text>

            <b-button to="/" variant="primary">Back</b-button>
        </b-card>
    
        <br/>
        <br/>
        <b-form @submit="onSubmit" @reset="onReset" v-if="show">
            <b-form-group id="input-group-1a"
                          label="Title:"
                          label-for="input-1a"
                          description="Book short description">
                <b-form-textarea id="input-1aa"
                                 v-model="book.title"
                                 rows="1"
                                 placeholder="Edit title"></b-form-textarea>
            </b-form-group>
            <br />
            <br />
                <b-form-group id="input-group-1s"
                              label="Short Description:"
                              label-for="input-1s"
                              description="Book short description">
                    <b-form-textarea id="input-1ss"
                                     v-model="book.shortDescr"
                                     rows="3"
                                     placeholder="Edit Short Description"></b-form-textarea>
                </b-form-group>
                <b-form-group id="input-group-1d"
                              label="Long Description:"
                              label-for="input-1d"
                              description="Book long description">
                    <b-form-textarea id="input-1dd"
                                     v-model="book.longDescr"
                                     rows="7"
                                     placeholder="Edit Long Description"></b-form-textarea>
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
            book: null,
            show: true
        }),
        mounted() {
            this.getBook();
                
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
                        alert('Book Information Edited Successfuly!');
                         this.getBook();
                        return res.data.results;
                       
        })
       
            },
            onReset(evt) {
                evt.preventDefault()
                // Reset our form values
                this.getBook();

                // Trick to reset/clear native browser form validation state
                this.show = false
                this.$nextTick(() => {
                    this.show = true
                })
            },
            getBook() {
                axios.get(`https://localhost:5001/books/${this.id}`)
                    .then(response => {
                        this.book = response.data;
                        //this.Console.log(this.book);
                    });
            }
        }
    }
</script>