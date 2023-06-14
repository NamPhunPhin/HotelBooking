<template>
  <div class="Navbar-Container">
    <div class="Logo-And-Nav">
      <div class="Logo">
        <router-link to="/"><img src="/images/logo.png" alt="" /></router-link>
      </div>
      <div class="Nav-List">
        <ul>
          <li class="TextMenu-Active">
            <router-link to="/">Khách sạn</router-link>
          </li>
          <li><router-link to="/contact">Liên lạc</router-link></li>
          <li><router-link to="/about">Giới thiệu</router-link></li>
        </ul>
      </div>
    </div>

    <div class="Cart-And-Account">
      <div class="Auth" v-if="!getAuthStatus.isLogined">
        <router-link to="/auth"><div class="btn">Đăng nhập</div></router-link>

        <router-link to="/auth/signup"
          ><div class="btn btn-outline-danger">Đăng ký</div></router-link
        >
      </div>

      <router-link to="/cart" class="position-relative Cart-Place">
        <span>
          <i class="fa-solid fa-cart-shopping"></i>
        </span>
      </router-link>

      <div
        class="Account"
        v-if="getAuthStatus.isLogined"
        @click="OpenPopUpAccount()"
      >
        <div>
          <img
            :src="
              getUser.avatar != null
                ? IMAGE_PATH + getUser.avatar
                : '/images/avatar_default.jpg'
            "
            alt=""
          />
        </div>
        <div>
          {{
            getUser.last_name &&
            getUser.last_name + " " + getUser.first_name &&
            getUser.first_name
          }}
        </div>

        <div class="Account_List" v-if="isPopUpAccount">
          <ul>
            <li
              style="
                border-start-start-radius: 10px;
                border-start-end-radius: 10px;
              "
              @click="AccountListHandleClick(0)"
            >
              Đặt hàng của tôi
            </li>
            <li @click="AccountListHandleClick(1)">Tin nhắn</li>
            <li @click="AccountListHandleClick(2)">Nhận xét</li>
            <li @click="AccountListHandleClick(3)">Hồ sơ</li>

            <li
              style="border-end-end-radius: 10px; border-end-start-radius: 10px"
              @click="LogOutHandleClick()"
            >
              Đăng xuất
            </li>
          </ul>
        </div>
      </div>

      <div class="coin" v-if="getAuthStatus.isLogined">
        <span></span>
        <span>{{ getUser.coin }}</span>
        <div @click="ClosePopUpAccount()" v-if="isLayOutPopUp"></div>
      </div>
    </div>

    <div class="Mobile-NavDropDown">
      <i
        v-if="!ShowMobileNav"
        class="fa-solid fa-bars"
        @click="OpenMenuMobileHandleClick()"
      ></i>

      <i
        v-if="ShowMobileNav"
        class="fa-solid fa-xmark"
        @click="OpenMenuMobileHandleClick()"
      ></i>
    </div>
  </div>
  <div class="Menu-Text-Mobile" ref="MobileMenu">
    <ul>
      <li @click="OpenMenuMobileHandleClick()" class="TextMenu-Active">
        <router-link to="/">Khách sạn</router-link>
      </li>
      <li @click="OpenMenuMobileHandleClick()">
        <router-link to="/contact">Liên lạc</router-link>
      </li>
      <li @click="OpenMenuMobileHandleClick()">
        <router-link to="/about">Giới thiệu</router-link>
      </li>
    </ul>
    <div class="Account-Nav-Mobile">
      <div>Tài khoản</div>
      <hr />
      <div class="Btn-Group">
        <div @click="OpenMenuMobileHandleClick()" class="btn btn-danger">
          <router-link to="/auth">Đăng nhập</router-link>
        </div>
        <div
          @click="OpenMenuMobileHandleClick()"
          class="btn btn-outline-danger"
        >
          <router-link to="/auth">Đăng ký</router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
export default {
  name: "NavbarComponent",

  data() {
    return {
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
      isPopUpAccount: false,
      ShowMobileNav: false,
      isLayOutPopUp: false,
    };
  },
  updated() {
    if (this.isPopUpAccount == false) {
      this.isLayOutPopUp = false;
    }
  },
  computed: {
    ...mapGetters("Auth", ["getUser", "getAuthStatus"]),
  },
  methods: {
    ...mapActions("Auth", ["LogOutAction"]),

    AccountListHandleClick(number) {
      this.$router.push(`/account/${number}`);
    },

    LogOutHandleClick() {
      this.LogOutAction();
      this.$router.go(this.$router.currentRoute);
    },

    ClosePopUpAccount() {
      this.isPopUpAccount = false;
      this.isLayOutPopUp = false;
    },

    OpenPopUpAccount() {
      this.isLayOutPopUp = true;
      this.isPopUpAccount = !this.isPopUpAccount;
    },

    // Phương thức mở và tắt Navbar của mobile.
    OpenMenuMobileHandleClick() {
      this.ShowMobileNav = !this.ShowMobileNav;
      this.$refs.MobileMenu.style.display = this.ShowMobileNav
        ? "block"
        : "none";
    },
  },
};
</script>

<style>
.Navbar-Container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-bottom: 2px solid var(--main-Color);
  height: 80px;
  font-family: var(--font-Mallory);
}

.Logo-And-Nav {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 2rem;
  margin-left: 5rem;
}

.Logo-And-Nav > .Logo > a > img {
  width: 80px;
  justify-content: center;
  align-items: center;
}

.Nav-List {
  display: flex;
  justify-content: center;
  align-items: center;
}

.Logo-And-Nav > .Nav-List > ul {
  list-style: none;
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 2rem;
  margin-bottom: 0 !important;
  font-weight: 500;
}

.Logo-And-Nav > .Nav-List > ul > li:hover {
  cursor: pointer;
  color: var(--main-Color);
}

.TextMenu-Active {
  color: var(--main-Color);
}

.Cart-And-Account {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-right: 5rem;
  gap: 2rem;
}

.Cart-And-Account > .Auth {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 1rem;
  font-size: 10px !important;
}

.Cart-And-Account > .Auth > a > div:nth-of-type(1) {
  color: red;
  font-size: 12px !important;
}

.Cart-And-Account > .Auth > a > div:nth-of-type(1):hover {
  background: var(--main-Color);
  color: white;
}

.Cart-And-Account > .Auth > a > div:nth-of-type(2) {
  font-size: 12px !important;
}

.Cart-And-Account > .Account {
  position: relative;
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 0.5rem;
  background: rgba(220, 53, 69, 0.1);
  height: 100%;
  padding: 5px 10px;
  font-size: 13px;
  border-radius: 5px;
  color: var(--main-Color);
  font-family: unset;
  cursor: pointer;
}

.Cart-And-Account > .Account:hover {
  background: var(--main-Color);
  color: white;
}

.Cart-And-Account > .Account > div:nth-of-type(1) > img {
  width: 25px;
  height: 25px;
  object-fit: cover;
  border-radius: 50%;
}

.Account_List {
  position: absolute;
  top: 100%;
  right: 0;
  width: 100%;
  color: black;
  z-index: 2001;
  background: white;
  margin-top: 10px;
  box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px,
    rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
  border-radius: 10px;
  min-width: 150px;
}

.Account_List > ul {
  list-style: none;
  margin: 0;
  padding: 0;
}

.Account_List > ul > li {
  width: 100%;
  padding: 10px 15px;
}

.Account_List > ul > li:hover {
  color: var(--main-Color);
  background: rgba(220, 53, 69, 0.1);
}

.fa-cart-shopping {
  font-size: 20px;
}

.Mobile-NavDropDown {
  display: none;
}

.Menu-Text-Mobile {
  display: none;
  z-index: 999;
}

.coin {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 0.3rem;
  border-radius: 5px;
}

.coin > span:nth-of-type(1) {
  background-image: url("../../public/images/dollar.png");
  display: inline-block;
  width: 20px;
  height: 20px;
  background-size: cover;
}

.Cart-Place {
  padding: 8px 10px;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 5px;
  color: var(--main-Color) !important;
  height: 100%;
}

.Cart-Place > span {
  display: flex;
  justify-content: center;
  align-items: center;
}

.Cart-Place > span > i {
  font-size: 18px;
}

.Cart-Place:hover {
  background: var(--main-Color);
  color: white !important;
}

.coin > div {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  z-index: 2000;
}

@media only screen and (max-width: 850px) {
  .Navbar-Container {
    border-bottom: unset;
    background: rgba(245, 245, 245, 0.6);
  }

  .Cart-And-Account {
    display: none;
  }

  .Nav-List {
    display: none;
  }

  .Mobile-NavDropDown {
    display: block;
  }

  .Mobile-NavDropDown > i {
    font-size: 30px;
    margin-right: 2rem;
    cursor: pointer;
  }

  .Logo-And-Nav {
    margin-left: 2rem;
  }

  .Menu-Text-Mobile {
    /* position: absolute; */
    width: 100%;
    z-index: 999;
    font-weight: 500 !important;
    background: rgba(245, 245, 245, 0.6);
  }

  .Menu-Text-Mobile > ul {
    display: flex;
    list-style: none;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 1rem;
  }

  .Login-Button {
    background: var(--main-Color) !important;
    color: white !important;
  }

  .Login-Button:hover {
    background: red !important;
  }

  .Menu-Text-Mobile > ul > li:hover {
    cursor: pointer;
    color: var(--main-Color);
    width: 100%;
    text-align: center;
  }

  .Account-Nav-Mobile {
    display: flex;
    flex-direction: column;
    padding: 20px;
    gap: 0.2rem;
    margin: 50px 0;
  }

  .Btn-Group {
    display: flex;
    flex-direction: column;
    gap: 1rem;
  }
}
</style>
