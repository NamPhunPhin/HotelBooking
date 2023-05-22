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
      <div class="Auth">
        <router-link to="/auth"><div class="btn">Đăng nhập</div></router-link>

        <router-link to="/auth/signup"
          ><div class="btn btn-outline-danger">Đăng ký</div></router-link
        >
      </div>

      <span class="position-relative">
        <i class="fa-solid fa-cart-shopping"></i>
      </span>
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
export default {
  name: "NavbarComponent",
  data() {
    return {
      ShowMobileNav: false,
    };
  },

  methods: {
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
  gap: 3rem;
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
