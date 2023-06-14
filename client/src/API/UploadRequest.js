import BaseUrl from "./BaseUrl";

export const UploadFile = (file) => {
  return BaseUrl.post("api/Upload", file, {
    headers: {
      "Content-Type": "multipart/form-data",
    },
  });
};
