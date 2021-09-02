var app = new Vue({
    el: '#app',
    data: {
        products: [],
        selectedProduct: null,
        selectedProductId:0,
        newStock: {
            productId: 0,
            description: "Volume",
            qty: 10
        }
         
    },
    mounted() {
        this.getStock();
    },
    methods: {
        getStock() {
            this.loading = true;
            axios.get('/Admin/stocks')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateStock() {
            this.loading = true;
            axios.put('/Admin/stocks', this.newStock)
                .then(res => {
                    console.log(res);
                    this.SelectedProduct.stock.splice(this.objIndex, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        },
        deleteStock(id,index) {
            this.loading = true;
            axios.delete('/Admin/stocks/' + id)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        },
        addStock() {
            this.loading = true;
            axios.post('/Admin/stocks', this.newStock)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = product.id;
        }
       
    }
});