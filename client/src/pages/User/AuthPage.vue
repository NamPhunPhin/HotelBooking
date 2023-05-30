<template>
  <div class="Auth-Container">
    <form action="">
      <div class="Button-Group">
        <button
          :class="isLogin && 'Btn-Switch-Active'"
          @click="
            (event) => {
              event.preventDefault();
              !isLogin && ButtonSwitchHandleClick(event);
            }
          "
        >
          Đăng nhập
        </button>
        <button
          :class="!isLogin && 'Btn-Switch-Active'"
          @click="
            (event) => {
              event.preventDefault();
              isLogin && ButtonSwitchHandleClick(event);
            }
          "
        >
          Đăng ký
        </button>
      </div>

      <h5 v-if="isLogin">
        Để đảm bảo an toàn, xin vui lòng đăng nhập để truy cập vào thông tin
      </h5>

      <div v-if="!isResult" class="text-danger mb-3 text-center">
        {{ errorMessage }}
      </div>

      <div v-if="!isLogin" class="Input-Group">
        <div class="Input-Field">
          <input type="text" placeholder="Họ" v-model="dataForm.LastName" />
        </div>

        <div class="Input-Field">
          <input type="text" placeholder="Tên" v-model="dataForm.FirstName" />
        </div>
      </div>

      <div class="Input-Field">
        <input type="text" placeholder="Email" v-model="dataForm.Email" />
      </div>

      <div class="Input-Field">
        <input
          type="password"
          placeholder="Mật khẩu"
          v-model="dataForm.Password"
        />
      </div>

      <div v-if="!isLogin" class="Input-Field">
        <input
          type="password"
          placeholder="Nhập lại mật khẩu"
          v-model="dataForm.Repassword"
        />
      </div>

      <div v-if="!isLogin" class="CheckBox-Field">
        <input
          id="mycheckbox"
          type="checkbox"
          @click="AcceptHandleClick()"
        />&ensp;
        <label for="mycheckbox">
          Tôi đồng ý với các Điều khoản sử dụng và Chính sách bảo mật của <br />
          Lisa.</label
        >
      </div>

      <div v-if="isLogin" class="Forget-Field">
        <span> Quên mật khẩu ?</span>
      </div>

      <div class="Button-Field">
        <button
          :disabled="
            (isAccept != true && isLogin != true) ||
            getAuthStatus.isloading == true
          "
          :class="
            !isLogin
              ? isAccept == true
                ? 'Button-Main Btn-Signup'
                : 'Btn-Signup Dissable-Button'
              : 'Button-Main Btn-Signup'
          "
          @click="SubmitHandleClick"
        >
          <div
            v-if="getAuthStatus.isloading"
            class="spinner-border text-light"
            role="status"
          >
            <span class="sr-only">Loading...</span>
          </div>
          <div v-else>Tiếp tục</div>
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import { useRoute } from "vue-router";
import { mapActions, mapGetters, mapMutations } from "vuex";
export default {
  name: "AuthPage",
  created() {
    const route = useRoute();

    const signup = route.params.signup;
    if (signup == "signup") {
      this.isLogin = false;
    } else {
      this.isLogin = true;
    }
  },

  data() {
    return {
      isLogin: false,
      isAccept: false,
      isResult: true,
      errorMessage: "",
      dataForm: {
        FirstName: "",
        LastName: "",
        Email: "",
        Password: "",
        Repassword: "",
      },
    };
  },
  computed: {
    ...mapGetters("Auth", ["getAuthResponse", "getUser", "getAuthStatus"]),
  },

  methods: {
    ...mapActions("Auth", ["SignUpAction", "LogInAction"]),
    ...mapMutations("Auth", ["AUTH_REQUEST"]),

    validateEmail(email) {
      return email.match(
        /^(([^<>()[\]\\.,;:\s@\\"]+(\.[^<>()[\]\\.,;:\s@\\"]+)*)|(\\".+\\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      );
    },

    async SubmitHandleClick(e) {
      e.preventDefault();

      if (this.isLogin) {
        if (
          this.dataForm.Email.length != 0 &&
          this.dataForm.Password.length != 0
        ) {
          if (this.validateEmail(this.dataForm.Email)) {
            const data = {
              email: this.dataForm.Email,
              password: this.dataForm.Password,
            };
            await this.LogInAction(data);
            if (this.getAuthResponse.result) {
              console.log("Thành Cồng"); //Điều hướng
              this.isResult = true;
              this.errorMessage = "";
            } else {
              this.isResult = this.getAuthResponse.result;
              this.errorMessage = this.getAuthResponse.message;
            }
          } else {
            this.isResult = false;
            this.errorMessage = "Email không đúng định dạng";
          }
        } else {
          this.isResult = false;
          this.errorMessage = "Hãy điền đầy đủ thông tin đăng nhập";
        }
      } else {
        if (
          this.dataForm.Email.length != 0 &&
          this.dataForm.Password.length != 0 &&
          this.dataForm.FirstName.length != 0 &&
          this.dataForm.LastName.length != 0 &&
          this.dataForm.Repassword.length != 0
        ) {
          if (this.validateEmail(this.dataForm.Email)) {
            if (this.dataForm.Password == this.dataForm.Repassword) {
              const data = {
                last_name: this.dataForm.LastName,
                first_name: this.dataForm.FirstName,
                email: this.dataForm.Email,
                password: this.dataForm.Password,
              };
              await this.SignUpAction(data);
              if (this.getAuthResponse.result) {
                console.log("Thành Cồng"); //Điều hướng
                this.isResult = true;
                this.errorMessage = "";
              } else {
                this.isResult = this.getAuthResponse.result;
                this.errorMessage = this.getAuthResponse.message;
              }
            } else {
              this.isResult = false;
              this.errorMessage = "Mật khẩu không trùng khớp";
            }
          } else {
            this.isResult = false;
            this.errorMessage = "Email không đúng định dạng";
          }
        } else {
          this.isResult = false;
          this.errorMessage = "Hãy điền đầy đủ thông tin đăng ký";
        }
      }
    },

    // Phương thức thay đổi từ đăng nhập sang đăng ký và ngược lại.
    ButtonSwitchHandleClick(event) {
      event.preventDefault();
      this.isLogin = !this.isLogin;
      this.isAccept = false;
      this.dataForm.FirstName = "";
      this.dataForm.LastName = "";
      this.dataForm.Email = "";
      this.dataForm.Password = "";
      this.dataForm.Repassword = "";
      this.errorMessage = "";
      this.isResult = "";
    },

    //Phương thức xác nhận đồng ý với điều khoản.
    AcceptHandleClick() {
      this.isAccept = !this.isAccept;
    },
  },
};
</script>

<style>
.Auth-Container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  margin: 100px 0;
}

.Auth-Container > form > h5 {
  width: 500px;
  word-wrap: break-word;
  margin-bottom: 20px;
}

.Auth-Container > form {
  width: 500px;
}

.Auth-Container > form > .Input-Group {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
}

.Input-Group > .Input-Field:nth-of-type(1) {
  margin-right: 10px;
}

.Input-Group > .Input-Field:nth-of-type(2) {
  margin-left: 10px;
}

.Input-Field {
  margin-bottom: 25px;
  background: rgba(0, 0, 0, 0.05);
  border-radius: 10px;
}

.Input-Field > input {
  width: 100%;
  padding: 10px;
  background: none;
  border: none;
  font-size: 20px;
  font-weight: bold;
}

.Input-Field > input:focus {
  outline: none;
}

.Btn-Signup {
  border: none;
  width: 100%;
  padding: 10px;
  font-size: 18px;
  font-weight: 500;
  color: white;
}

.Button-Group {
  display: flex;
  border: 1px solid rgba(0, 0, 0, 0.1);
  margin-bottom: 40px;
  border-radius: 10px;
}

.Button-Group > button {
  width: 100%;
  padding: 10px;
  border-radius: 10px;
  font-weight: 500;
  background: none;
  border: none;
}

.Btn-Switch-Active {
  background: var(--main-Color) !important;
  color: white;
}

.CheckBox-Field {
  margin-bottom: 25px;
  word-break: break-all;
  display: flex;
  justify-content: center;
  align-items: center;
}

.CheckBox-Field > input {
  width: 20px;
  height: 20px;
  accent-color: var(--main-Color);
}
.CheckBox-Field > label {
  cursor: pointer;
}

.Forget-Field > span {
  display: flex;
  justify-content: flex-end;
  margin-bottom: 25px;
}

.Dissable-Button {
  background: rgba(220, 53, 69, 0.8);
  border-radius: 10px;
}
</style>
