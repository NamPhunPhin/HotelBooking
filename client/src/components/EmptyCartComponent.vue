<template lang="">
    <div class="EmptyCart container">
        <div class="box text-center">
            <img src="../../public/images/Empty_Cart.svg" alt="" style="width: 100px; height: 100px">
            <h3 class="mt-5">YOUR CART IS EMPTY</h3>
            <p class="mt-4 mb-5">Shop for hotels, flights, cars and attractions to plan your next trip</p>
            <a class="btn btn-primary mt-3" href="">Search for travel</a>
        </div>
    </div>
</template>
<script>
export default {
    name : "EmptyCartComponent",
}
</script>
<style>
    .EmptyCart{
        padding-top: 125px;
    }

    .btn{
        padding: 12px;
        width: 350px;
    }

    p{
        font-size: 19px;
        font-weight: 400;
    }
</style>