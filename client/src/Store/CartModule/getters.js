export default {
  getCart(state) {
    return state.Cart;
  },

  getTotal(state) {
    return state.Cart.reduce((a, b) => a + b.total, 0);
  },
};
