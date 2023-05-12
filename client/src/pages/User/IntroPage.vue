<template lang="">
  <div class="IntroPage">
    <!-- Carousel -->
    <div class="block-1">
      <div
        id="carouselExampleControls"
        class="carousel slide"
        data-bs-ride="carousel"
      >
        <div class="carousel-inner">
          <div class="carousel-item active">
            <img
              src="../../../public/images/carousel_1.png"
              class="d-block w-100"
              alt="..."
            />
          </div>
          <div class="carousel-item">
            <img
              src="../../../public/images/carousel_2.jpg"
              class="d-block w-100"
              alt="..."
            />
          </div>
          <div class="carousel-item">
            <img
              src="../../../public/images/carousel_3.jpg"
              class="d-block w-100"
              alt="..."
            />
          </div>
        </div>
        <button
          class="carousel-control-prev"
          type="button"
          data-bs-target="#carouselExampleControls"
          data-bs-slide="prev"
        >
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Previous</span>
        </button>
        <button
          class="carousel-control-next"
          type="button"
          data-bs-target="#carouselExampleControls"
          data-bs-slide="next"
        >
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Next</span>
        </button>
      </div>
    </div>
    <!-- Hot Location -->
    <div class="block-2 row m-0 p-5 justify-content-around">
      <h1 class="title_block-2 text-center mb-5">ĐỊA ĐIỂM THỊNH HÀNH</h1>
      <div class="card bg-dark m-2 text-white col-md-3 p-0 border-0">
        <img
          src="../../../public/images/Da_nang.jpg"
          class="card-img"
          alt="..."
        />
        <div class="card-img-overlay">
          <h3 class="card-title">Đà Nẵng</h3>
        </div>
      </div>
      <div class="card bg-dark m-2 text-white col-md-3 p-0 border-0">
        <img
          src="../../../public/images/Tp_hcm.jpg"
          class="card-img"
          alt="..."
        />
        <div class="card-img-overlay">
          <h3 class="card-title">TP Hồ chí Minh</h3>
        </div>
      </div>
      <div class="card bg-dark m-2 text-white col-md-3 p-0 border-0">
        <img
          src="../../../public/images/Da_lat.jpg"
          class="card-img"
          alt="..."
        />
        <div class="card-img-overlay">
          <h3 class="card-title">Đà Lạt</h3>
        </div>
      </div>
    </div>
    <!-- About Luxury -->
    <div class="block-3">
      <div class="card bg-dark text-white">
        <img
          src="../../../public/images/bg_luxury.jpg"
          class="card-img"
          alt="..."
        />
        <div class="card-img-overlay text-center">
          <p class="card-title">Luxury</p>
          <p class="card-text mb-0">"Live grand with spacious"</p>
          <button class="btn"><u>Explore More</u></button>
        </div>
      </div>
    </div>
    <!-- About View -->
    <div class="block-4">
      <div class="card bg-dark text-white">
        <img
          src="../../../public/images/bg_overview.jpg"
          class="card-img"
          alt="..."
        />
        <div class="card-img-overlay text-center">
          <p class="card-title">View</p>
          <p class="card-text mb-0">"One step close to Paradise"</p>
          <button class="btn"><u>Explore More</u></button>
        </div>
      </div>
    </div>
    <!-- Gallery image -->
    <div class="block-5 pt-5 pb-5">
      <h1 class="title_block-5 text-center mb-5">ẢNH SƯU TẬP</h1>
      <div class="container">
        <div
          class="row min-vh-100 row-cols-1 row-cols-md-4 gy-4 justify-content-around mt-5 mb-5 p-0"
        >
          <div class="col m-0 p-0 text-center">
            <img
              src="../../../public/images/gallery_1.jpg"
              class="img-fluid gallery-item"
              alt="..."
              data-bs-toggle="modal"
              data-bs-target="#Modal-gallery"
            />
          </div>
          <div class="col m-0 p-0 text-center">
            <img
              src="../../../public/images/gallery_2.jpg"
              class="img-fluid gallery-item"
              alt="..."
              data-bs-toggle="modal"
              data-bs-target="#Modal-gallery"
            />
          </div>
          <div class="col m-0 p-0 text-center">
            <img
              src="../../../public/images/gallery_3.jpg"
              class="img-fluid gallery-item"
              alt="..."
              data-bs-toggle="modal"
              data-bs-target="#Modal-gallery"
            />
          </div>
          <div class="col m-0 p-0 text-center">
            <img
              src="../../../public/images/gallery_4.jpg"
              class="img-fluid gallery-item"
              alt="..."
              data-bs-toggle="modal"
              data-bs-target="#Modal-gallery"
            />
          </div>
          <div class="col m-0 p-0 text-center">
            <img
              src="../../../public/images/gallery_5.jpg"
              class="img-fluid gallery-item"
              alt="..."
              data-bs-toggle="modal"
              data-bs-target="#Modal-gallery"
            />
          </div>
          <div class="col m-0 p-0 text-center">
            <img
              src="../../../public/images/gallery_6.jpg"
              class="img-fluid gallery-item"
              alt="..."
              data-bs-toggle="modal"
              data-bs-target="#Modal-gallery"
            />
          </div>
          <div class="col m-0 p-0 text-center">
            <img
              src="../../../public/images/gallery_7.jpg"
              class="img-fluid gallery-item"
              alt="..."
              data-bs-toggle="modal"
              data-bs-target="#Modal-gallery"
            />
          </div>
          <div class="col m-0 p-0 text-center">
            <img
              src="../../../public/images/gallery_8.jpg"
              class="img-fluid gallery-item"
              alt="..."
              data-bs-toggle="modal"
              data-bs-target="#Modal-gallery"
            />
          </div>
        </div>
      </div>
    </div>
    <!-- Modal Gallery Img -->
    <div
      class="modal fade"
      id="Modal-gallery"
      tabindex="-1"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <button
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <div class="modal-body">
            <img
              src="../../../public/images/gallery_7.jpg"
              class="img-fluid img-modal"
              alt="..."
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "IntroPage",
};

document.addEventListener("click", function (e) {
  if (e.target.classList.contains("gallery-item")) {
    const src = e.target.getAttribute("src");
    document.querySelector(".img-modal").src = src;
  }
});
</script>
<style>
@import url("https://fonts.googleapis.com/css2?family=Dancing+Script&family=Gilda+Display&family=Italianno&family=Lora:ital,wght@0,400;0,500;0,600;0,700;1,400;1,500;1,600;1,700&family=Playfair+Display:ital,wght@0,400;0,500;0,600;0,700;0,800;0,900;1,400;1,500;1,600;1,700;1,800;1,900&family=Poppins:ital,wght@0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap");

:root {
  --font-Display: "Playfair Display", serif;
  --font-Dancing: "Dancing Script", cursive;
}

/* Block-2 */
.block-2 {
  background: #bdbdbd81;
  width: 100%;
  font-family: var(--font-Dancing);
}

.title_block-2 {
  color: rgb(220, 53, 69);
}

.block-2 .card {
  cursor: pointer;
  overflow: hidden;
}

.block-2 .card-title {
  visibility: hidden;
  color: rgb(220, 53, 69);
}

.block-2 .card-img-overlay:hover .card-title {
  visibility: visible;
  animation: fadeintop 0.5s ease;
}

.block-2 .card-img {
  transition: 0.2s;
}

.block-2 .card:hover .card-img {
  transform: scale(1.2);
}

@keyframes fadeintop {
  0% {
    transform: translateY(-30px);
    opacity: 0;
  }

  100% {
    transform: translateY(0px);
    opacity: 1;
  }
}

.block-2 .card-img-overlay {
  text-align: center;
}

/* Block-3 */
.block-3 {
  font-family: var(--font-Dancing);
  font-size: 40px;
}

.block-3 .card {
  border: none;
  border-radius: 0;
}

.block-3 .card-img-overlay {
  margin-top: 300px;
  margin-left: 800px;
  color: rgb(220, 53, 69);
}

.block-3 .card-title {
  font-size: 60px;
}

.block-3 button {
  font-size: 20px;
  color: beige;
}

/* Responsive block-3 */
@media screen and (max-width: 767px) {
  .block-3 .card-img-overlay {
    margin-top: 0px;
    margin-left: 0px;
  }

  .block-3 .card-title {
    font-size: 40px;
  }

  .block-3 {
    font-family: var(--font-Dancing);
    font-size: 20px;
  }
}

/* Block-4 */
.block-4 {
  font-family: var(--font-Dancing);
  font-size: 40px;
}

.block-4 .card {
  border: none;
  border-radius: 0;
}

.block-4 .card-img-overlay {
  margin-top: 100px;
  color: rgb(220, 53, 69);
}

.block-4 .card-title {
  font-size: 60px;
}

.block-4 button {
  font-size: 20px;
  color: beige;
}

/* Responsive block-4 */
@media screen and (max-width: 767px) {
  .block-4 .card-img-overlay {
    margin-top: 0px;
  }

  .block-4 .card-title {
    font-size: 40px;
  }

  .block-4 {
    font-family: var(--font-Dancing);
    font-size: 20px;
  }
}

/* block-5 */
.block-5 {
  background: #bdbdbd81;
  width: 100%;
  font-family: var(--font-Dancing);
}

.block-5 h1{
    color: rgb(220, 53, 69);
}

.modal-body {
  text-align: center;
}

.block-5 img {
  cursor: pointer;
  overflow: hidden;
  transition: 0.5s;
}

.block-5 img:hover {
  transform: scale(1.2);
  z-index: 99;
}
</style>
