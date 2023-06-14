<template>
  <div class="Account-Wrapper">
    <div class="Account-SideBar">
      <ul>
        <li
          :class="isSiteBarNumber == 0 && 'Active-Bar'"
          @click="SiteBarHandleClick(0)"
        >
          <i class="fa-solid fa-calendar-days"></i>
          <div>Đơn đặt chổ của tôi</div>
        </li>
        <li
          :class="isSiteBarNumber == 1 && 'Active-Bar'"
          @click="SiteBarHandleClick(1)"
        >
          <i class="fa-solid fa-message"></i>
          <div>Tin nhắn từ khách sạn</div>
        </li>
        <li
          :class="isSiteBarNumber == 2 && 'Active-Bar'"
          @click="SiteBarHandleClick(2)"
        >
          <i class="fa-solid fa-star"></i>
          <div>Nhận xét</div>
        </li>
        <li
          :class="isSiteBarNumber == 3 && 'Active-Bar'"
          @click="SiteBarHandleClick(3)"
        >
          <i class="fa-solid fa-user"></i>
          <div>Hồ sơ</div>
        </li>
        <li
          :class="isSiteBarNumber == 4 && 'Active-Bar'"
          @click="SiteBarHandleClick(4)"
        >
          <i class="fa-solid fa-handshake"></i>
          <div>Trở thành đối tác</div>
        </li>
      </ul>
    </div>
    <div class="Account-Content">
      <ProfileComponent
        v-if="getAuthStatus.isLogined && isSiteBarNumber == 3"
      />

      <PartnerComponent
        v-if="getAuthStatus.isLogined && isSiteBarNumber == 4"
      />
    </div>
  </div>
</template>

<script>
import ProfileComponent from "../../components/ProfileComponent.vue";
import PartnerComponent from "../../components/PartnerComponent.vue";
import { mapGetters } from "vuex";
export default {
  components: {
    ProfileComponent,
    PartnerComponent,
  },
  data() {
    return {
      isSiteBarNumber: 0,
    };
  },

  created() {
    if (this.$route.params.id) {
      this.isSiteBarNumber = this.$route.params.id;
    }
  },

  beforeUpdate() {
    this.isSiteBarNumber = this.$route.params.id;
  },

  computed: {
    ...mapGetters("Auth", ["getAuthStatus"]),
  },

  methods: {
    SiteBarHandleClick(number) {
      this.isSiteBarNumber = number;
      this.$route.params.id = this.isSiteBarNumber;
    },
  },
};
</script>

<style>
.Account-Wrapper {
  display: flex;
  min-height: 500px;
}

.Account-SideBar {
  width: 30%;
  padding: 30px 0 30px 10%;
  box-shadow: rgba(0, 0, 0, 0.2) 0px 12px 28px 0px,
    rgba(0, 0, 0, 0.1) 0px 2px 4px 0px,
    rgba(255, 255, 255, 0.05) 0px 0px 0px 1px inset;
  z-index: 1000;
}

.Account-SideBar > ul {
  list-style: none;
  margin: 0;
  padding: 0;
}

.Account-SideBar > ul > li {
  padding: 15px;
  display: flex;
  align-items: center;
  font-size: 17px;
  font-weight: 600;
  gap: 0.5rem;
  color: var(--main-Color);
  cursor: pointer;
  border-right: 3px solid transparent;
}

.Active-Bar {
  background: linear-gradient(to right, white, rgba(220, 53, 69, 0.1));
  border-right: 3px solid var(--main-Color) !important;
}

.Account-SideBar > ul > li:hover {
  background: var(--main-Color);
  color: white;
}

.Account-SideBar > ul > li > i {
  font-size: 25px;
  width: 10%;
}

.Account-SideBar > ul > li > div {
  width: 85%;
}

.Account-Content {
  width: 70%;
  padding: 30px 10% 30px 30px;
  background: rgb(245, 247, 250);
}
</style>
