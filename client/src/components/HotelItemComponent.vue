<template>
  <div class="Hotel-Item-Container">
    <img src="/images/khachsan1.jpg" alt="" />
    <div class="Content-Wrapper">
      <div class="Content-Top">
        <div class="Left-Content">
          <h5>
            Căn hộ LuxHomes Saigon – Vinhomes Central Park (LuxHomes Saigon -
            Vinhomes Central Park)
          </h5>
          <div class="Star-Hotel">
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
            <i class="fa-solid fa-star"></i>
          </div>
          <div class="Hotel-Address">
            <i class="fa-solid fa-location-dot"></i> Bình Thạnh, Hồ Chí Minh
          </div>
          <div class="Around-City">
            <i class="fa-solid fa-city"></i> Cách trung tâm 0.3 km
          </div>
        </div>
        <div class="Right-Content">
          <div class="Content-Rating">
            <div>Tuyệt vời</div>
            <div>555 Nhận xét</div>
          </div>

          <div class="Number-Rating"><div>8.4</div></div>
        </div>
      </div>

      <div class="Content-Bottom">
        <div class="Content-Service">
          <div><i class="fa-solid fa-bed"></i> Giường dành cho 2 người</div>

          <div>Huỷ Miễn Phí, Wifi, Bãi Đậu Xe</div>

          <div>Chỉ còn một phòng</div>
        </div>

        <div class="Content-Price">
          <div>Giảm 60%</div>
          <div><strike>1.888.000 ₫</strike></div>
          <div>888.000 ₫</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HotelItemComponent",
};
</script>

<style>
.Hotel-Item-Container {
  display: flex;
  padding: 15px;
  gap: 0.5rem;
  background: rgb(245, 247, 250);
  border-radius: 10px;
  cursor: pointer;
}

.Hotel-Item-Container:hover {
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
}

.Hotel-Item-Container > img {
  width: 20%;
  border-radius: 10px;
  /* object-fit: contain; */
  height: auto;
}

.Content-Wrapper {
  width: 80%;
}

.Content-Top {
  display: flex;
}

.Left-Content {
  width: 70%;
}

.Left-Content > h5 {
  font-family: unset;
  font-weight: bold;
}

.Right-Content {
  width: 30%;
  display: flex;
  justify-content: flex-end;
  gap: 0.5rem;
}

.Right-Content > .Content-Rating {
  width: auto;
  font-size: 13px;
  text-align: end;
}

.Right-Content > .Number-Rating > div {
  background: var(--main-Color);
  display: inline-block;
  border-radius: 50% 50% 50% 0;
  color: white;
  font-weight: bold;
  padding: 5px;
}

.Right-Content > .Content-Rating > div:nth-of-type(1) {
  font-weight: bold;
}

.Right-Content > .Content-Rating > div:nth-of-type(2) {
  color: #5a5b79;
}

.Star-Hotel > i {
  font-size: 13px;
  margin: 5px 0;
}

.Hotel-Address {
  font-size: 13px;
  margin: 5px 0;
}

.Around-City {
  font-size: 13px;
  margin: 5px 0;
}

.Content-Bottom {
  background: white;
  padding: 10px;
  border-radius: 5px;
  display: flex;
  align-items: center;
}

.Content-Bottom > .Content-Service {
  width: 70%;
  display: flex;
  justify-items: center;
  flex-direction: column;
}

.Content-Bottom > .Content-Service > div:nth-of-type(1) {
  font-weight: bold;
  font-family: unset;
  font-size: 15px;
  color: black;
}

.Content-Bottom > .Content-Service > div {
  font-size: 13px;
  color: #7e7e7e;
}

.Content-Bottom > .Content-Price {
  width: 30%;
}

.Content-Price {
  display: flex;
  flex-direction: column;
  justify-content: end;
  align-items: end;
}

.Content-Price > div {
  font-size: 20px;
  font-weight: bold;
}

.Content-Price > div:nth-of-type(1) {
  padding: 5px;
  font-size: 13px;
  background: lightgreen;
  border-radius: 5px;
}

.Content-Price > div > strike {
  color: #9b9b9b;
  font-size: 15px;
}
</style>
