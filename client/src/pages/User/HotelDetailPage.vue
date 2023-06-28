<template>
  <div class="Wrapper-PopUp" v-if="isPageLoading">
    <div class="Focus-Layout-Loading">
      <div class="Message-Searching">
        <img src="/images/agoji-parachute.gif" alt="" />
        <h5>VUI LÒNG ĐỢI MỘT VÀI GIÂY</h5>
        <div>Chúng tôi sẽ luôn mang lại trải nghiệm tốt nhất cho bạn.</div>
      </div>
    </div>
  </div>

  <div v-show="!isPageLoading" class="Hotel-Detail-Container">
    <div :class="view.topOfPage && 'Search-Nav'">
      <SearchNavbarComponent :is-detail-page="true" />
    </div>
    <div class="Hotel-Detail-Wrapper container">
      <div class="Hotel-Detail-Header">
        <div class="Text-Hotel">
          <div class="Text-Left">
            <h4>
              {{ Hotel_Detail.name }}
              <span>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star"></i>
                <i class="fa-solid fa-star"></i>
              </span>
            </h4>
            <div>
              <i class="fa-solid fa-location-dot"></i>
              {{ Hotel_Detail.address }}
            </div>
            <div>
              <i class="fa-solid fa-hotel"></i>
              {{ Hotel_Detail.description }}
            </div>
          </div>

          <div class="Text-Right">
            <div class="text-danger">
              <strike v-if="Hotel_Detail.min_discount">{{
                FormatCurrency(Hotel_Detail.min_price)
              }}</strike>
              {{
                Hotel_Detail.min_discount != 0
                  ? FormatCurrency(Hotel_Detail.min_price_discount)
                  : FormatCurrency(Hotel_Detail.min_price)
              }}
            </div>
            <div>
              <button @click="scrollToRoom">Chọn Phòng</button>
            </div>
          </div>
        </div>
        <div class="Hotel-Detail-Image">
          <div>
            <img
              :src="
                Hotel_Detail.thumbnail
                  ? IMAGE_PATH + Hotel_Detail.thumbnail
                  : `/images/khachsan1.jpg`
              "
              alt=""
            />
          </div>
          <div>
            <div class="Images-Hotel">
              <img
                :src="
                  Hotel_Detail != '' &&
                  IMAGE_PATH + Hotel_Detail.images[0].image_name
                "
                alt=""
              />
              <img
                :src="
                  Hotel_Detail != '' &&
                  IMAGE_PATH + Hotel_Detail.images[1].image_name
                "
                alt=""
              />
              <img
                :src="
                  Hotel_Detail != '' &&
                  IMAGE_PATH + Hotel_Detail.images[2].image_name
                "
                alt=""
              />
            </div>
            <div class="Images-Hotel">
              <img
                :src="
                  Hotel_Detail != '' &&
                  IMAGE_PATH + Hotel_Detail.images[3].image_name
                "
                alt=""
              />
              <img
                :src="
                  Hotel_Detail != '' &&
                  IMAGE_PATH + Hotel_Detail.images[4].image_name
                "
                alt=""
              />
              <img
                :src="
                  Hotel_Detail != '' &&
                  IMAGE_PATH + Hotel_Detail.images[5].image_name
                "
                alt=""
              />
            </div>
          </div>
        </div>

        <div ref="myRoom"></div>

        <div class="Block-Detail-Header">
          <div>
            <div class="Title">Tiện nghi và dịch vụ</div>
            <div class="Location-Block">
              <div
                class="Services-Area"
                v-for="(ser, index) in ServicesData"
                :key="index"
                @mouseover="PopUpHandleMouseOver(ser.service_id)"
                @mouseout="PopUpHandleMouseOut(ser.service_id)"
              >
                <span v-html="ser.icon"></span> {{ " " + ser.service_name }}
                <div
                  class="Service-Details-PopUp"
                  :id="`Service_Details_${ser.service_id}`"
                >
                  <ul>
                    <li
                      ref=""
                      v-for="(det, index) in ServiceDetailsData"
                      :key="index"
                      v-show="ser.service_id == det.service_id"
                    >
                      <div>
                        <span v-html="det.icon"></span>
                        {{ " " + det.service_detail_name }}
                      </div>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>

          <div>
            <div class="Title">Đặc điêm</div>

            <div class="Service-Second">
              <div>
                <i class="fa-solid fa-city"></i>

                {{
                  Hotel_Detail.distance_citycenter != 0
                    ? `Cách trung tâm thành phố
                ${Hotel_Detail.distance_citycenter}km`
                    : `Bên trong trung tâm thành phố `
                }}
              </div>
            </div>
          </div>

          <div>
            <div class="Title text-end">Tuyệt Vời <span>8.1</span></div>

            <div class="Service-Block">
              <div>
                <div class="d-flex justify-content-between">
                  <span>Dịch vụ</span> <span>8</span>
                </div>
                <div class="progress" style="height: 10px">
                  <div
                    class="progress-bar bg-danger"
                    role="progressbar"
                    style="width: 70%"
                    aria-valuenow="100"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>
              <div>
                <div class="d-flex justify-content-between">
                  <span>Vệ sinh</span> <span>8</span>
                </div>
                <div class="progress" style="height: 10px">
                  <div
                    class="progress-bar bg-danger"
                    role="progressbar"
                    style="width: 70%"
                    aria-valuenow="100"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>
              <div>
                <div class="d-flex justify-content-between">
                  <span>Thiết bị</span> <span>8</span>
                </div>
                <div class="progress" style="height: 10px">
                  <div
                    class="progress-bar bg-danger"
                    role="progressbar"
                    style="width: 70%"
                    aria-valuenow="100"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>
              <div>
                <div class="d-flex justify-content-between">
                  <span>Vị trí</span> <span>8</span>
                </div>
                <div class="progress" style="height: 10px">
                  <div
                    class="progress-bar bg-danger"
                    role="progressbar"
                    style="width: 70%"
                    aria-valuenow="100"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="Loading" v-if="isRoomLoading == false">
        <div class="spinner-grow text-primary" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
        <div class="spinner-grow text-secondary" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
        <div class="spinner-grow text-success" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
        <div class="spinner-grow text-danger" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
        <div class="spinner-grow text-warning" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
        <div class="spinner-grow text-info" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
        <div class="spinner-grow text-dark" role="status">
          <span class="visually-hidden">Loading...</span>
        </div>
      </div>

      <div
        class="Room-Hotel mt-3 mb-3"
        v-for="(item, index) in Room_Data"
        :key="index"
      >
        <h4>{{ item.name }}</h4>
        <RoomListComponent :room-data="item" :hotel-data="Hotel_Detail" />
      </div>

      <div class="Room-Hotel mt-3 mb-3">
        <RecommendRoomComponent />
      </div>

      <div class="Rating-Customer mt-3 mb-3">
        <h4 class="mt-3 mb-5">
          Nhận Xét Của <span class="text-danger">Khách Hàng</span>
        </h4>
        <div class="Chart-Rating">
          <div>
            <div><span>8.1</span></div>
            <div>Rất Hài Lòng</div>
          </div>

          <div>
            <div>
              <div class="Proccess-Line">
                <div>
                  <span>Dịch vụ</span><span class="text-danger">8.1</span>
                </div>
                <div class="progress" style="height: 10px">
                  <div
                    class="progress-bar bg-danger"
                    role="progressbar"
                    style="width: 70%"
                    aria-valuenow="100"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>

              <div class="Proccess-Line mt-3">
                <div>
                  <span>Vị trí</span><span class="text-danger">8.1</span>
                </div>
                <div class="progress" style="height: 10px">
                  <div
                    class="progress-bar bg-danger"
                    role="progressbar"
                    style="width: 80%"
                    aria-valuenow="100"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>
            </div>

            <div>
              <div class="Proccess-Line">
                <div>
                  <span>Vệ sinh</span><span class="text-danger">8.1</span>
                </div>
                <div class="progress" style="height: 10px">
                  <div
                    class="progress-bar bg-danger"
                    role="progressbar"
                    style="width: 50%"
                    aria-valuenow="100"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>

              <div class="Proccess-Line mt-3">
                <div>
                  <span>Thiết bị</span><span class="text-danger">8.1</span>
                </div>
                <div class="progress" style="height: 10px">
                  <div
                    class="progress-bar bg-danger"
                    role="progressbar"
                    style="width: 40%"
                    aria-valuenow="100"
                    aria-valuemin="0"
                    aria-valuemax="100"
                  ></div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="Comment">
          <div class="Customer-Comment">
            <div class="Customer-Info">
              <div class="Avatar-And-Name">
                <img src="/images/room4.jpg" alt="" />
                <div>Quoc Thanh</div>
              </div>

              <ul>
                <li><i class="fa-solid fa-city"></i> Loft King bed room</li>
                <li><i class="fa-solid fa-city"></i> Stayed in April 2023</li>
                <li><i class="fa-solid fa-city"></i> Business travelers</li>
                <li><i class="fa-solid fa-city"></i> Loft King bed room</li>
              </ul>
            </div>

            <div class="Customer-Text">
              <div><span>8.1</span> Tốt</div>
              <div>
                Very Disappointed Poor service and unfriendly communication.
                leaked water from the sink. cant open windows Very Disappointed
                Poor service and unfriendly communication. leaked water from the
                sink. cant open windows Very Disappointed Poor service and
                unfriendly communication. leaked water from the sink. cant open
                windows
              </div>
              <div>Posted December 17, 2021</div>
            </div>
          </div>
          <div class="Customer-Comment">
            <div class="Customer-Info">
              <div class="Avatar-And-Name">
                <img src="/images/room4.jpg" alt="" />
                <div>Quoc Thanh</div>
              </div>

              <ul>
                <li><i class="fa-solid fa-city"></i> Loft King bed room</li>
                <li><i class="fa-solid fa-city"></i> Stayed in April 2023</li>
                <li><i class="fa-solid fa-city"></i> Business travelers</li>
                <li><i class="fa-solid fa-city"></i> Loft King bed room</li>
              </ul>
            </div>

            <div class="Customer-Text">
              <div><span>8.1</span> Tốt</div>
              <div>
                Very Disappointed Poor service and unfriendly communication.
                leaked water from the sink. cant open windows
              </div>
              <div>Posted December 17, 2021</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {
  GetServiceByHotelId,
  GetServiceDetailsByHotelId,
} from "@/API/ServicesRequest";
import { GetHotelDetails } from "@/API/HotelRequest";
import { GetRoomByHotelId } from "@/API/RoomsRequest";
import { FormatCurrency } from "@/service/FormatService";
import RecommendRoomComponent from "../../components/RecommendRoomComponent.vue";
import RoomListComponent from "../../components/RoomListComponent.vue";
import SearchNavbarComponent from "../../components/SearchNavbarComponent.vue";

export default {
  name: "HotelDetailPage",
  components: {
    SearchNavbarComponent,
    RoomListComponent,
    RecommendRoomComponent,
  },

  data() {
    return {
      isPageLoading: true,
      ServicesData: "",
      ServiceDetailsData: "",
      Hotel_Detail: "",
      Room_Data: "",
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
      isRoomLoading: false,
      view: {
        topOfPage: false,
      },
    };
  },

  async created() {
    const Hotel_Detail_Request = await GetHotelDetails(this.$route.params.id);
    this.Hotel_Detail = Hotel_Detail_Request.data;
    this.Hotel_Detail.images.sort((a, b) => b.image_id - a.image_id);

    const ServicesRequest = await GetServiceByHotelId(this.$route.params.id);
    this.ServicesData = ServicesRequest.data;

    const ServiceDetailsRequest = await GetServiceDetailsByHotelId(
      this.$route.params.id
    );
    this.ServiceDetailsData = ServiceDetailsRequest.data;

    if (
      ServiceDetailsRequest.data &&
      ServicesRequest.data &&
      Hotel_Detail_Request.data
    ) {
      this.isPageLoading = false;
    }

    const Room_Request = await GetRoomByHotelId(this.$route.params.id);
    if (Room_Request.data) {
      this.isRoomLoading = true;
      this.Room_Data = Room_Request.data;
    }
  },

  methods: {
    PopUpHandleMouseOver(id) {
      const popUp = document.getElementById(`Service_Details_${id}`);
      popUp.style.display = "block";
    },

    PopUpHandleMouseOut(id) {
      const popUp = document.getElementById(`Service_Details_${id}`);
      popUp.style.display = "none";
    },

    FormatCurrency(number) {
      return FormatCurrency(number);
    },

    scrollToRoom() {
      this.$refs.myRoom.scrollIntoView({
        behavior: "smooth",
      });
    },

    NavSearchHandleScroll() {
      document.documentElement.scrollTop > 100
        ? (this.view.topOfPage = true)
        : (this.view.topOfPage = false);
    },
  },

  beforeMount() {
    window.addEventListener("scroll", this.NavSearchHandleScroll);
  },
};
</script>

<style>
.Hotel-Detail-Container {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.Wrapper-PopUp {
  min-height: 500px;
}

.Hotel-Detail-Header {
  display: flex;
  justify-content: space-between;
  flex-direction: column;
  padding: 20px;
  background: rgb(245, 247, 250);
  border-radius: 5px;
}

.Text-Hotel {
  display: flex;
  gap: 1rem;
}

.Text-Left {
  width: 80%;
}

.Text-Left > h4 > span > i {
  font-size: 15px;
}

.Text-Left > div {
  font-size: 14px;
  color: #506d92;
  line-height: 30px;
}

.Text-Right {
  width: 20%;
  text-align: end;
}

.Text-Right {
  width: 20%;
  text-align: end;
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  justify-content: space-around;
}

.Text-Right > div > strike {
  font-weight: bold;
  font-size: 15px;
  color: #0f294d;
  text-align: right;
}

.Text-Right > div {
  font-weight: bold;
  font-size: 24px;
  color: #0f294d;
  text-align: right;
}

.Text-Right > div > button {
  font-weight: bold;
  font-size: 20px;
  color: #0f294d;
  border: none;
  width: 100%;
  background: var(--main-Color);
  color: white;
  padding: 10px;
  border-radius: 5px;
}

.Text-Right > div > button:hover {
  border: 2px solid var(--main-Color);
  background: none;
  color: var(--main-Color);
}

.Hotel-Detail-Image {
  display: flex;
  gap: 5px;
  margin: 20px 0;
}

.Hotel-Detail-Image > div:nth-of-type(1) {
  width: 40%;
  height: 355px;
}

.Hotel-Detail-Image > div:nth-of-type(1) > img {
  width: 100%;
  height: 100%;
  border-radius: 10px;
  object-fit: cover;
}

.Hotel-Detail-Image > div:nth-of-type(2) {
  display: flex;
  flex-direction: column;
  height: 100%;
  width: 60%;
  gap: 5px;
}

.Images-Hotel {
  display: flex;
  gap: 5px;
}

.Images-Hotel > img {
  height: 175px;
  width: 33.3333333333%;
  border-radius: 10px;
}

.Block-Detail-Header {
  display: flex;
  gap: 1rem;
}

.Block-Detail-Header > div:nth-of-type(1) {
  display: flex;
  gap: 1rem;
  width: 50%;
  flex-direction: column;
  background: white;
  border-radius: 10px;
  padding: 10px 30px;
}

.Block-Detail-Header > div:nth-of-type(1) > .Title {
  font-weight: bold;
  font-size: 20px;
}

.Block-Detail-Header > div:nth-of-type(2) > .Title {
  font-weight: bold;
  font-size: 20px;
}

.Block-Detail-Header > div:nth-of-type(2) {
  display: flex;
  gap: 1rem;
  width: 25%;
  flex-direction: column;
  background: white;
  border-radius: 10px;
  padding: 10px;
  padding: 10px 30px;
}

.Block-Detail-Header > div:nth-of-type(3) {
  display: flex;
  gap: 1rem;
  width: 25%;
  flex-direction: column;
  background: white;
  border-radius: 10px;
  padding: 10px;
  padding: 10px 30px;
}

.Block-Detail-Header > div:nth-of-type(3) > .Title {
  font-weight: bold;
}

.Block-Detail-Header > div:nth-of-type(3) > .Title > span {
  padding: 5px;
  background: var(--main-Color);
  border-radius: 30% 0 30% 30%;
  color: white;
}

.Location-Block {
  display: grid;
  grid-template-columns: 50% 50%;
  gap: 1rem;
  /* align-items: center; */
  font-size: 13px;
  font-weight: 500;
}

.Service-Block {
  display: grid;
  grid-template-columns: 50% 50%;
  gap: 1rem;
  align-items: center;
  font-size: 13px;
  font-weight: 500;
}

.Service-Second {
  display: grid;
  grid-template-columns: 100%;
  gap: 1rem;
  align-items: center;
  font-size: 15px;
  font-weight: 500;
}

.Room-Hotel {
  background: rgb(245, 247, 250);
  border-radius: 5px;
  padding: 20px;
}

.Chart-Rating {
  display: grid;
  grid-template-columns: 20% 80%;
  margin: 20px 0;
}

.Chart-Rating > div:nth-of-type(1) {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.Chart-Rating > div:nth-of-type(1) > div:nth-of-type(1) > span {
  font-size: 30px;
  display: inline;
  padding: 5px 10px;
  font-weight: bold;
  color: white;
  background: var(--main-Color);
  border-radius: 10px 0 10px 10px;
}

.Chart-Rating > div:nth-of-type(1) > div:nth-of-type(2) {
  font-size: 20px;
  font-weight: bold;
  color: var(--main-Color);
}

.Chart-Rating > div:nth-of-type(2) {
  display: flex;
  gap: 5rem;
}

.Chart-Rating > div:nth-of-type(2) > div {
  width: 50%;
}

.Proccess-Line > div:nth-of-type(1) {
  display: flex;
  font-weight: bold;
  justify-content: space-between;
}

.Rating-Customer {
  padding: 20px;
  background: rgb(245, 247, 250);
  border-radius: 5px;
}

.Customer-Comment {
  display: grid;
  grid-template-columns: 20% 80%;
}

.Customer-Comment {
  display: grid;
  grid-template-columns: 20% 80%;
  margin: 30px 0;
}

.Avatar-And-Name {
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.Avatar-And-Name > img {
  width: 50px;
  height: 50px;
  border-radius: 50%;
  object-fit: cover;
}

.Avatar-And-Name > div {
  font-weight: bold;
  font-size: 16px;
}

.Customer-Info > ul {
  padding: 0;
  margin: 10px 0;
  list-style: none;
}

.Customer-Info > ul > li {
  font-size: 12px;
  margin-top: 10px;
  color: #8e9aad;
  word-break: break-word;
  font-weight: 500;
}

.Customer-Text > div {
  line-height: 40px;
}

.Customer-Text > div:nth-of-type(1) {
  font-weight: bold;
  color: var(--main-Color);
}

.Customer-Text > div:nth-of-type(2) {
  word-break: break-all;
}

.Customer-Text > div:nth-of-type(1) > span {
  padding: 3px 5px;
  font-weight: bold;
  background: var(--main-Color);
  border-radius: 10px 0 10px 10px;
  color: white;
}

.Customer-Text > div:nth-of-type(3) {
  text-align: right;
  color: #8e9aad;
  font-size: 14px;
}

.Comment {
  margin-top: 80px;
}

.Loading {
  display: flex;
  justify-content: center;
  gap: 1rem;
  align-items: center;
  margin: 150px 0;
}

.Services-Area {
  position: relative;
  font-size: 15px;
  cursor: pointer;
}

.Services-Area:hover {
  color: var(--main-Color);
}

.Service-Details-PopUp {
  box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
  overflow-y: auto;
  max-height: 300px;
  position: absolute;
  padding: 10px;
  left: 80%;
  top: 0;
  background: white;
  border-radius: 10px;
  display: none;
  justify-content: center;
  flex-direction: row;
  z-index: 99999;
  width: 100%;
  font-size: 15px;
}

.Service-Details-PopUp::-webkit-scrollbar {
  display: none;
}

.Service-Details-PopUp > ul {
  margin: 0;
  padding: 0;
  list-style: none;
  width: 100%;
}

.Service-Details-PopUp > ul > li {
  margin: 10px 0;
}

.Focus-Layout-Loading {
  background-color: rgba(0, 0, 0, 0.5);
  bottom: 0;
  left: 0;
  position: fixed;
  right: 0;
  top: 0;
  z-index: 9999;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Message-Searching {
  background: white;
  padding: 30px;
  z-index: 99999;
  width: 30%;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 10px;
  opacity: unset;
  flex-direction: column;
}

.Message-Searching > h5 {
  font-family: unset;
  color: var(--main-Color);
}

.Message-Searching > div {
  font-weight: 600;
  text-align: center;
}

.Message-Searching > img {
  margin: 10px 0;
}
</style>
