<template>
  <div class="RoomList-Container">
    <div class="Left-Site">
      <img src="/images/room4.jpg" alt="" />
      <h6>1 giường king hoặc 2 giường đơn</h6>
      <ul>
        <li><i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km</li>
        <li><i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km</li>
        <li><i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km</li>
        <li><i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km</li>
        <li><i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km</li>
        <li><i class="fa-solid fa-city"></i> Cách trung tâm thành phố 3km</li>
      </ul>
    </div>
    <div class="Right-Site">
      <div class="Nav-Type">
        <div>Tóm Tăt</div>
        <div>Sức Chứa</div>
        <div>Giá Phòng</div>
      </div>

      <div class="Room-List">
        <div class="Room-Item">
          <div>
            Lợi ích Bãi đậu xe, WiFi miễn phí, Nước uống Giá cực thấp! (không
            hoàn tiền) <br />
            Lợi ích tùy chọn:Bữa sáng với giá 79.492 ₫ <br />
            Tặng thưởng Cashback: 136.083 ₫ Giảm giá
          </div>
          <div class="text-center">
            <i class="fa-solid fa-user"></i> <i class="fa-solid fa-user"></i>
          </div>
          <div class="Buy-Area">
            <div>
              <div><span>80%</span></div>
              <div><strike>699.000</strike> 7.899.999</div>
            </div>
            <div>
              <button>Đặt Ngay</button>
              <button>Thêm Vào Đẩy Hàng</button>
            </div>
          </div>
        </div>

        <div class="Room-Item">
          <div>
            Lợi ích Bãi đậu xe, WiFi miễn phí, Nước uống Giá cực thấp! (không
            hoàn tiền) <br />
            Lợi ích tùy chọn:Bữa sáng với giá 79.492 ₫ <br />
            Tặng thưởng Cashback: 136.083 ₫ Giảm giá
          </div>
          <div class="text-center">
            <i class="fa-solid fa-user"></i> <i class="fa-solid fa-user"></i>
          </div>
          <div class="Buy-Area">
            <div>
              <div><span>80%</span></div>
              <div><strike>699.000</strike> 7.899.999</div>
            </div>
            <div>
              <button>Đặt Ngay</button>
              <button>Thêm Vào Đẩy Hàng</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "RoomListComponent",
};
</script>

<style>
.RoomList-Container {
  display: grid;
  grid-template-columns: 20% 78%;
  gap: 2%;
}

.Left-Site > img {
  width: 100%;
}

.Left-Site > h6 {
  font-weight: 700;
  font-family: unset;
  margin: 10px 0;
}

.Left-Site > ul {
  list-style: none;
  padding: 0;
  margin: 0;
  display: flex;
  font-size: 13px;
  flex-direction: column;
  gap: 0.5rem;
  color: rgb(117, 111, 111);
  font-weight: 600;
}

.Right-Site {
  display: flex;
  flex-direction: column;
  gap: 5px;
}

.Nav-Type {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 5px;
}

.Nav-Type > div:nth-of-type(2) {
  width: 20%;
  background: white;
}

.Nav-Type > div {
  width: 40%;
  background: white;
  padding: 10px;
  border-radius: 10px;
  text-align: center;
  font-weight: bold;
}

.Room-List {
  display: flex;
  flex-direction: column;
  width: 100%;
  border-radius: 10px;
}

.Room-Item {
  margin: 5px 0;
  background: white;
  padding: 10px;
  display: grid;
  grid-template-columns: 39% 20% 39%;
  gap: 1%;
  border-radius: 10px;
}

.Room-Item:hover {
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
}

.Room-Item > div {
  background: rgb(245, 247, 250);
  border-radius: 10px;
  padding: 10px;
  width: 100%;
  border-radius: 10px;
}

.Buy-Area {
  display: flex;
  justify-content: center;
  align-items: end;
  gap: 0.5rem;
}

.Buy-Area > div {
  width: 50%;
}

.Buy-Area > div:nth-of-type(1) {
  text-align: end;
}

.Buy-Area > div:nth-of-type(1) > div:nth-of-type(1) > span {
  background: lightskyblue;
  padding: 5px 10px;
  border-radius: 5px;
  font-weight: bold;
  color: white;
}

.Buy-Area > div:nth-of-type(1) > div:nth-of-type(2) > strike {
  font-size: 14px;
}

.Buy-Area > div:nth-of-type(1) > div:nth-of-type(2) {
  font-size: 20px;
  margin-top: 10px;
}

.Buy-Area > div:nth-of-type(2) > button:nth-of-type(1) {
  border: none;
  width: 100%;
  font-weight: bold;
  background: var(--main-Color);
  padding: 10px;
  color: white;
  margin-top: 10px;
  border-radius: 5px;
}

.Buy-Area > div:nth-of-type(2) > button:nth-of-type(2) {
  border: none;
  width: 100%;
  font-weight: bold;
  background: lightseagreen;
  padding: 10px;
  color: white;
  margin-top: 10px;
  border-radius: 5px;
}
</style>
