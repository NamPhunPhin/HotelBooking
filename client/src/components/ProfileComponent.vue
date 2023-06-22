<template>
  <div class="Profile-Wrapper">
    <div class="Title">Thông tin người dùng</div>
    <div class="Block-1">
      <div
        class="Profile-Info"
        v-if="isEditNumber != 0 || isEditNumber == null"
      >
        <div class="Profile-Left">
          <div class="Avatar-Image">
            <img
              :src="
                getUser.avatar != null
                  ? IMAGE_PATH + getUser.avatar
                  : `/images/avatar_default.jpg`
              "
              alt=""
            />
          </div>
          <div class="Profile-Info-Content">
            <div class="Profile-Info-Title">Họ & Tên</div>
            <div class="Profile-Info-Name">
              {{ getUser.last_name + " " + getUser.first_name }}
            </div>
          </div>
        </div>
        <div @click="OpenEditHandleClick(0)" class="Profile-Action">
          Chỉnh sửa
        </div>
      </div>

      <div class="Edit-Profile" v-if="isEditNumber == 0">
        <div class="Avatar-Image-Edit">
          <div class="Image-Icon">
            <img
              :src="
                ProfileData.avatarPreview
                  ? ProfileData.avatarPreview
                  : ProfileData.avatar
                  ? IMAGE_PATH + ProfileData.avatar
                  : '/images/avatar_default.jpg'
              "
              ref="avatar"
              alt=""
            />
            <i
              class="fa-solid fa-camera-retro"
              @click="OpenFilePickerHandleClick()"
            ></i>
          </div>
          <input type="file" ref="avatarImage" @change="onChangeFile" />
        </div>
        <div class="Name-Edit">
          <div>
            <input
              type="text"
              placeholder="Họ"
              v-model="ProfileData.lastName"
            />
          </div>
          <div>
            <input
              type="text"
              placeholder="Tên"
              v-model="ProfileData.firstName"
            />
          </div>
        </div>

        <div class="Button-Action">
          <button @click="CloseEditHandleClick()">Huỷ</button>
          <button
            :class="
              (ProfileData.firstName == '' || ProfileData.lastName == '') &&
              'bg-secondary'
            "
            @click="UpdateProfile()"
            :disabled="
              ProfileData.firstName == '' || ProfileData.lastName == ''
            "
          >
            Lưu
          </button>
        </div>
      </div>
    </div>

    <div class="Block-2">
      <div class="Profile-Info">
        <div class="Profile-Left">
          <div class="Profile-Info-Content">
            <div class="Profile-Info-Title">Email</div>
            <div class="Profile-Info-Name">
              <i>{{
                getUser.email != null
                  ? getUser.email
                  : "Email của bạn đang trống"
              }}</i>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="Block-3">
      <div
        class="Profile-Info"
        v-if="isEditNumber != 1 || isEditNumber == null"
      >
        <div class="Profile-Left">
          <div class="Profile-Info-Content">
            <div class="Profile-Info-Title">Địa chỉ</div>
            <div class="Profile-Info-Name">
              <i :class="!getUser.address && 'text-muted'">{{
                getUser.address != null
                  ? getUser.address
                  : "Hãy cập nhật địa chỉ nhà của bạn"
              }}</i>
            </div>
          </div>
        </div>
        <div @click="OpenEditHandleClick(1)" class="Profile-Action">
          Chỉnh sửa
        </div>
      </div>

      <div class="Edit-Profile" v-if="isEditNumber == 1">
        <div class="Name-Edit">
          <label class="Lable-Edit">Địa chỉ</label>
          <div class="w-100">
            <input
              type="text"
              class="w-100"
              placeholder="Địa chỉ"
              v-model="ProfileData.address"
            />
          </div>
        </div>

        <div class="Button-Action">
          <button @click="CloseEditHandleClick()">Huỷ</button>
          <button
            @click="UpdateProfile()"
            :disabled="ProfileData.address == ''"
            :class="ProfileData.address == '' && 'bg-secondary'"
          >
            Lưu
          </button>
        </div>
      </div>
    </div>

    <div class="Block-4">
      <div
        class="Profile-Info"
        v-if="isEditNumber != 2 || isEditNumber == null"
      >
        <div class="Profile-Left">
          <div class="Profile-Info-Content">
            <div class="Profile-Info-Title">Số điện thoại</div>
            <div class="Profile-Info-Name">
              <i :class="!getUser.contact_number && 'text-muted'">{{
                getUser.contact_number != null
                  ? getUser.contact_number
                  : "Hãy cập nhật số điện thoại của bạn"
              }}</i>
            </div>
          </div>
        </div>
        <div @click="OpenEditHandleClick(2)" class="Profile-Action">
          Chỉnh sửa
        </div>
      </div>

      <div class="Edit-Profile" v-if="isEditNumber == 2">
        <div class="Name-Edit">
          <label class="Lable-Edit">Số điện thoại</label>
          <div class="w-100">
            <input
              type="text"
              class="w-100"
              placeholder="Số điện thoại"
              v-model="ProfileData.phone"
            />
          </div>
        </div>

        <div class="Button-Action">
          <button @click="CloseEditHandleClick()">Huỷ</button>
          <button
            @click="UpdateProfile()"
            :disabled="ProfileData.phone == ''"
            :class="ProfileData.phone == '' && 'bg-secondary'"
          >
            Lưu
          </button>
        </div>
      </div>
    </div>

    <div class="Block-5">
      <div
        class="Profile-Info"
        v-if="isEditNumber != 3 || isEditNumber == null"
      >
        <div class="Profile-Left">
          <div class="Profile-Info-Content">
            <div class="Profile-Info-Title">Mật khẩu</div>
            <div class="Profile-Info-Name">
              <div class="Dot-Password">
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
                <i class="fa-sharp fa-solid fa-circle"></i>
              </div>
            </div>
          </div>
        </div>
        <div @click="OpenEditHandleClick(3)" class="Profile-Action">
          Chỉnh sửa
        </div>
      </div>

      <div class="Edit-Profile" v-if="isEditNumber == 3">
        <div v-if="!changePasswordResult.result" class="Message text-danger">
          *{{ changePasswordResult.message }}
        </div>
        <div class="Name-Edit">
          <label class="Lable-Edit">Mật khẩu cũ</label>
          <div class="w-100">
            <input
              type="password"
              class="w-100"
              placeholder="Mật khẩu cũ"
              v-model="ProfileData.oldPassword"
            />
          </div>

          <label class="Lable-Edit">Mật khẩu mới</label>
          <div class="w-100">
            <input
              type="password"
              class="w-100"
              placeholder="Mật khẩu mới"
              v-model="ProfileData.newPassword"
            />
          </div>

          <label class="Lable-Edit">Xác nhận mật khẩu mới</label>
          <div class="w-100">
            <input
              type="password"
              class="w-100"
              placeholder="Xác nhận mật khẩu mới"
              v-model="ProfileData.rePassword"
            />
          </div>
        </div>

        <div class="Button-Action">
          <button @click="CloseEditHandleClick()">Huỷ</button>
          <button
            :disabled="
              ProfileData.newPassword == null ||
              ProfileData.oldPassword == null ||
              ProfileData.rePassword == null
            "
            :class="
              (ProfileData.newPassword == null ||
                ProfileData.oldPassword == null ||
                ProfileData.rePassword == null) &&
              'bg-secondary'
            "
            @click="ChangePasswordHandleClick()"
          >
            Lưu
          </button>
        </div>
      </div>
    </div>
    <vue-basic-alert :duration="300" :closeIn="3000" ref="alert" />
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import { UpdateProfile, ChangePassword } from "../API/UserRequest";
import { UploadFile } from "../API/UploadRequest";
import VueBasicAlert from "vue-basic-alert";

export default {
  name: "ProfileComponent",
  data() {
    return {
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
      isEditNumber: null,
      ProfileData: {
        avatar: null,
        firstName: null,
        lastName: null,
        phone: null,
        address: null,
        oldPassword: null,
        newPassword: null,
        rePassword: null,
        avatarFile: null,
      },
      changePasswordResult: {
        result: true,
        message: null,
      },
    };
  },
  created() {
    this.ProfileData.firstName = this.getUser.first_name;
    this.ProfileData.lastName = this.getUser.last_name;
    this.ProfileData.phone = this.getUser.contact_number;
    this.ProfileData.address = this.getUser.address;
    this.ProfileData.avatar = this.getUser.avatar;
    this.ProfileData.avatarPreview = null;
  },
  components: {
    VueBasicAlert,
  },
  computed: {
    ...mapGetters("Auth", ["getUser", "getAuthStatus"]),
  },
  methods: {
    ...mapActions("Auth", ["UpdateUserLocalStorage"]),

    AlertShow(type, hearder, message) {
      this.$refs.alert.showAlert(
        type, // There are 4 types of alert: success, info, warning, error

        message, // Message of the alert
        hearder // Header of the alert
      );
    },

    async ChangePasswordHandleClick() {
      if (this.ProfileData.newPassword == this.ProfileData.rePassword) {
        let data = {
          old_Password: this.ProfileData.oldPassword,
          new_Password: this.ProfileData.newPassword,
        };
        const changePasswordRes = await ChangePassword(
          this.getUser.user_id,
          data
        );
        console.log(changePasswordRes);
        if (changePasswordRes.data.result == false) {
          this.changePasswordResult.result = false;
          this.changePasswordResult.message = changePasswordRes.data.message;
        } else {
          this.AlertShow("success", "Thành Công", "Đổi mật khẩu thành công");
          this.changePasswordResult.result = true;
          this.changePasswordResult.message = "Đổi mật khẩu thành công";
          this.isEditNumber = null;
        }
      } else {
        this.changePasswordResult.result = false;
        this.changePasswordResult.message =
          "Xác nhận mật khẩu không trùng khớp";
      }
    },

    OpenFilePickerHandleClick() {
      this.$refs.avatarImage.showPicker();
    },

    OpenEditHandleClick(number) {
      this.isEditNumber = number;
    },

    CloseEditHandleClick() {
      this.isEditNumber = null;
      this.ProfileData.firstName = this.getUser.first_name;
      this.ProfileData.lastName = this.getUser.last_name;
      this.ProfileData.phone = this.getUser.contact_number;
      this.ProfileData.address = this.getUser.address;
      this.ProfileData.avatar = this.getUser.avatar;
      this.ProfileData.avatarPreview = null;
    },
    onChangeFile(e) {
      this.ProfileData.avatarFile = e.target.files[0];
      this.ProfileData.avatar = e.target.files[0].name;
      const theReader = new FileReader();

      theReader.onloadend = async () => {
        this.ProfileData.avatarPreview = await theReader.result;
      };
      theReader.readAsDataURL(this.ProfileData.avatarFile);
    },

    async UpdateProfile() {
      var FlagResult = false;
      console.log(this.ProfileData.avatar);
      if (
        this.ProfileData.avatar != null ||
        this.ProfileData.address != null ||
        this.ProfileData.firstName != null ||
        this.ProfileData.lastName != null ||
        this.ProfileData.phone != null
      ) {
        var data = {
          last_name: this.ProfileData.lastName
            ? this.ProfileData.lastName
            : null,
          first_name: this.ProfileData.firstName
            ? this.ProfileData.firstName
            : null,
          contact_number: this.ProfileData.phone
            ? this.ProfileData.phone
            : null,
          address: this.ProfileData.address ? this.ProfileData.address : null,
          avatar: this.ProfileData.avatarFile
            ? this.ProfileData.avatarFile.name
            : null,
        };

        const resultProfile = await UpdateProfile(this.getUser.user_id, data);
        FlagResult = resultProfile.data.result;
      }
      if (this.ProfileData.avatarFile != null) {
        const formData = new FormData();
        formData.append("file", this.ProfileData.avatarFile);
        const resultUpload = await UploadFile(formData);
        if (resultUpload.data.message == "Đã tồn tại") {
          FlagResult = true;
        } else {
          FlagResult = resultUpload.data.result;
        }
      }

      if (FlagResult) {
        let UpdateUser = {
          first_name: this.ProfileData.firstName,
          last_name: this.ProfileData.lastName,
          contact_number: this.ProfileData.phone,
          address: this.ProfileData.address,
          avatar: this.ProfileData.avatar,
        };
        this.UpdateUserLocalStorage(UpdateUser);
        this.AlertShow(
          "success",
          "Thành Công",
          "Thay đổi thông tin cá nhân thành công"
        );
        FlagResult = false;
      }
      this.isEditNumber = null;
    },
  },
};
</script>

<style>
.Profile-Wrapper {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.Profile-Wrapper > .Title {
  font-size: 20px;
  font-weight: 600;
}

.Profile-Info {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: white;
  padding: 30px 20px;
  border-radius: 10px;
}

.Profile-Info:hover {
  box-shadow: rgba(0, 0, 0, 0.1) 0px 10px 15px -3px,
    rgba(0, 0, 0, 0.05) 0px 4px 6px -2px;
}

.Profile-Left {
  display: flex;
  align-items: center;
  gap: 1rem;
}

.Profile-Left > .Avatar-Image {
  width: 70px;
  border-radius: 50%;
}

.Profile-Left > .Avatar-Image > img {
  width: 70px;
  height: 70px;
  object-fit: cover;
  border-radius: 50%;
}

.Profile-Info-Title {
  font-size: 16px;
  font-weight: bold;
}

.Profile-Info-Name {
  font-size: 17px;
}

.Profile-Action {
  font-size: 15px;
  font-weight: bold;
  color: var(--main-Color);
  cursor: pointer;
}

.Edit-Profile {
  background: white;
  padding: 5%;
  border-radius: 10px;
}

.Block-3 > .Edit-Profile,
.Block-4 > .Edit-Profile,
.Block-5 > .Edit-Profile {
  padding: 30px 20px !important;
}

.Avatar-Image-Edit {
  width: 100%;
  display: flex;
  justify-content: center;
}

.Avatar-Image-Edit > input {
  display: none !important;
}

.Image-Icon {
  width: 150px;
  height: 150px;
  object-fit: cover;
  position: relative;
}

.Image-Icon > img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  border-radius: 50%;
  border: 3px solid rgb(245, 247, 250);
}

.Image-Icon > i {
  font-size: 20px;
  background: rgb(245, 247, 250);
  padding: 10px;
  position: absolute;
  bottom: 5px;
  right: 5px;
  border-radius: 50%;
  border: 3px solid rgb(245, 247, 250);
  cursor: pointer;
}

.Image-Icon > i:hover {
  border: 3px solid rgba(220, 53, 69, 0.7);
  color: rgba(220, 53, 69, 0.9);
}

.Name-Edit {
  display: flex;
  gap: 1rem;
  align-items: center;
  flex-direction: column;
  margin: 30px 0;
}

.Name-Edit > div {
  background: rgba(0, 0, 0, 0.05) !important;
  border-radius: 10px;
}

.Name-Edit > div > input {
  background: none !important;
  border: none;
  font-weight: bold;
  font-size: 20px;
  padding: 10px 20px;
}

.Name-Edit > div > input:focus {
  outline: none;
}

.Button-Action {
  width: 100%;
  display: flex;
  justify-content: end;
  gap: 1rem;
}

.Button-Action > button {
  border: none;
  font-weight: bold;
  font-size: 15px;
  padding: 10px;
  width: 10%;
}

.Button-Action > button:nth-of-type(1) {
  background: none;
  color: var(--main-Color);
}

.Button-Action > button:nth-of-type(2) {
  background: var(--main-Color);
  color: white;
  border-radius: 10px;
}

.Block-1 > .Profile-Info {
  background: linear-gradient(to right, #f12711, #f5af19);
}

.Block-1 > .Profile-Info > .Profile-Action {
  color: white !important;
}

.Block-1 > .Profile-Info > .Profile-Left > .Avatar-Image > img {
  border: 2px solid white !important;
}

.Block-1 > .Profile-Info > .Profile-Left > .Profile-Info-Content {
  color: white !important;
}

.Lable-Edit {
  width: 100%;
  font-size: 16px;
  font-weight: bold;
  /* font-family: unset; */
}

.Dot-Password {
  display: flex;
  gap: 0.3rem;
  font-size: 10px;
  margin: 15px 0 0 0;
}
.vue-alert.top {
  bottom: 25px;
  top: unset;
}
</style>
