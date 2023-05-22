<template>
  <div class="Hotel-Detail-Container">
    <SearchNavbarComponent />
    <div class="Hotel-Detail-Wrapper container">
      <div class="Hotel-Detail-Header">
        <div class="Text-Hotel">
          <div class="Text-Left">
            <h4>
              Khách sạn Eastin Grand Saigon (Eastin Grand Hotel Saigon)
              <span>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star"></i>
                <i class="fa-solid fa-star"></i>
              </span>
            </h4>
            <div>
              <i class="fa-solid fa-location-dot"></i> 253 Nguyễn Văn Trỗi, Phú
              Nhuận, TP. Hồ Chí Minh, 70000, Việt Nam
            </div>
            <div>
              <i class="fa-solid fa-hotel"></i>
              Tọa lạc tại trung tâm Thành phố Hồ Chí Minh, Khách sạn Eastin
              Grand Saigon cách Chùa Vĩnh Nghiêm và Bảo tàng Chứng tích Chiến
              tranh 5 phút lái xe.
            </div>
          </div>

          <div class="Text-Right">
            <div class="text-danger"><strike>6.900.000</strike> 7.900.000</div>
            <div>
              <button>Chọn Phòng</button>
            </div>
          </div>
        </div>
        <div class="Hotel-Detail-Image">
          <div>
            <img src="/images/detail1.jpg" alt="" />
          </div>
          <div>
            <div class="Images-Hotel">
              <img src="/images/detail2.jpg" alt="" />
              <img src="/images/detail2.jpg" alt="" />
              <img src="/images/detail2.jpg" alt="" />
            </div>
            <div class="Images-Hotel">
              <img src="/images/detail2.jpg" alt="" />
              <img src="/images/detail2.jpg" alt="" />
              <img src="/images/detail2.jpg" alt="" />
            </div>
          </div>
        </div>

        <div class="Block-Detail-Header">
          <div>
            <div class="Title">Đặc điểm nổi bật</div>
            <div class="Location-Block">
              <div>
                <i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km
              </div>
              <div>
                <i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km
              </div>
              <div>
                <i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km
              </div>
              <div><i class="fa-solid fa-ban"></i> Huỷ đặt phòng miễn phí</div>
              <div>
                <i class="fa-solid fa-broom"></i> Yêu cầu thêm nhân viên vệ sinh
              </div>
            </div>
          </div>

          <div>
            <div class="Title">Tiện nghi và dịch vụ</div>

            <div class="Service-Block">
              <div>
                <i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km
              </div>
              <div><i class="fa-solid fa-ban"></i> Huỷ đặt phòng miễn phí</div>
              <div>
                <i class="fa-solid fa-broom"></i> Yêu cầu thêm nhân viên vệ sinh
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

      <div class="Room-Hotel mt-3 mb-3">
        <h4>Premium Deluxe Room Non smoking</h4>
        <RoomListComponent />
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
};
</script>

<style>
.Hotel-Detail-Container {
  display: flex;
  flex-direction: column;
  gap: 1rem;
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
  justify-content: start;
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
</style>
