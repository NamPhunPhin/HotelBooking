<template lang="">
  <div class="Contact">
    <div class="m-0">
      <div class="p-0 m-0">
        <iframe
          src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.7347384755294!2d106.6847209239447!3d10.754915259592359!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f0570be0adb%3A0x4415c64da6a9bd39!2zNjEwIFbDtSBWxINuIEtp4buHdCwgQ-G6p3UgS2hvLCBRdeG6rW4gMSwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaWV0bmFt!5e0!3m2!1sen!2s!4v1684158384855!5m2!1sen!2s"
          width="800"
          height="600"
          style="border: 0; width: 100%;padding: 0;"
          allowfullscreen=""
          loading="lazy"
          referrerpolicy="no-referrer-when-downgrade"
        ></iframe>
      </div>
      <div class="form-bg">
        <h5><b>Lisa Co.,Ltd</b></h5>
        <p class="mb-1 p-0">Tầng 5, 610 Võ Văn Kiệt, Phường Cầu Kho, Quận 1, Tp.HCM</p>
        <p class="mb-1 p-0">[P]: (08) 2244 7799</p>
        <p class="p-0">[E]: info@lisa.com.vn</p>
        <form class="form mt-1">
          <div class="form-floating mb-3">
            <input
              type="text"
              class="form-control"
              id="Name"
              placeholder="Name"
              required
            />
            <label for="Name" class="form-label">Name</label>
          </div>
          <div class="form-floating mb-3">
            <input
              type="email"
              class="form-control"
              id="Email"
              placeholder="Email"
              required
            />
            <label for="Email" class="form-label">Email</label>
          </div>
          <div class="form-floating mb-3">
            <input
              type="text"
              class="form-control"
              id="Subject"
              placeholder="Subject"
              required
            />
            <label for="Subject" class="form-label">Subject</label>
          </div>
          <div class="form-floating mb-3">
            <textarea
              class="form-control"
              placeholder="Massage"
              id="Message"
              style="height: 100px"
              required
            ></textarea>
            <label for="Message">Message</label>
          </div>
          <div class="mb-3">
            <input type="submit" class="btn btn-primary" value="Send message" />
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
export default {};
</script>
<style>
.Contact {
  width: 100%;
}

input,
textarea {
  width: 400px !important;
}

input[type="submit"]{
    width: 150px !important;
    background-color: var(--main-Color);
    border: none;
}

input[type="submit"]:hover {
    background: var(--gray-Color);
}

.form {
  width: 100% !important;
}

.form-bg{
    position: absolute;
    transform: translate(900px,-600px);
    background: var(--custom-Color);
    padding: 20px;
    font-family: var(--font-Anton);
}

/* Reponsive form */
@media screen and (max-width: 767px) {
    .form-bg{
        position: relative ;
        transform: translate(0px,0px);
    }
}
</style>
