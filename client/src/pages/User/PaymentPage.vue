<template lang="">
    <div class="PaymentPage">
        <div class="container">
            <div class="row">
                <div class="col-8"><InfoUserComponent /></div>
                <div class="col-4"><PaymentDetailComponent /></div>
            </div>
        </div>
    </div>
</template>
<script>
import InfoUserComponent from '@/components/InfoUserComponent.vue';
import PaymentDetailComponent from '@/components/PaymentDetailComponent.vue';

export default {
    name : "PaymentPage",
    components : {InfoUserComponent,PaymentDetailComponent},
}
</script>
<style scoped>
    .PaymentPage{
        padding-top: 25px;
        padding-bottom: 25px;
    }
</style>