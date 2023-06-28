export const FormatCurrency = (number) => {
  return new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
  }).format(number);
};

export function GET_NUMBER_DATE(date1, date2) {
  // Chuyển đổi các ngày thành đối tượng Date
  const startDate = new Date(date1);
  const endDate = new Date(date2);

  // Tính toán số lượng milliseconds giữa hai ngày
  const timeDiff = endDate.getTime() - startDate.getTime();

  // Chuyển đổi milliseconds thành số ngày
  const daysDiff = Math.ceil(timeDiff / (1000 * 3600 * 24));

  // Trả về số ngày
  return daysDiff;
}
