/*
 * Contact Info Edit
*/
contactdetailsview = new Vue({
    el: "#ContactDetailsEdit",
    data: {
        loading: true,
        detailsModel: {
            profile: {
                image: {
                    id: null,
                    media: null
                },
                name: null,
                aka: null,
                intro: null
            },
            openingTimes: {
                monday: {
                    open: null,
                    close: null
                },
                tuesday: {
                    open: null,
                    close: null
                },
                wednesday: {
                    open: null,
                    close: null
                },
                thursday: {
                    open: null,
                    close: null
                },
                friday: {
                    open: null,
                    close: null
                },
                saturday: {
                    open: null,
                    close: null
                },
                sunday: {
                    open: null,
                    close: null
                }
            },
            contactInfo: {
                email: "",
                ukPhone: "",
                usaPhone: "",
                address: ""
            }
        }
    },
    computed: {
        profileImageUrl: function () {
            if (this.detailsModel.profile.image != null && this.detailsModel.profile.image.id != null) {
                return piranha.utils.formatUrl("~/manager/api/media/url/" + this.detailsModel.profile.image.id + "/220");
            } else {
                return piranha.utils.formatUrl("~/manager/assets/img/empty-image.png");
            }
        }
    },
    methods: {
        bindContactDetailsModel: function (result) {
            this.detailsModel = result;
        },
        saveContactDetails: function () {
            var self = this;
            var model = {
                profile: {
                    image: {
                        id: self.detailsModel.profile.image.id
                    },
                    name: self.detailsModel.profile.name,
                    aka: self.detailsModel.profile.aka,
                    intro: self.detailsModel.profile.intro
                },
                openingTimes: self.detailsModel.openingTimes,
                contactInfo: self.detailsModel.contactInfo
            }

            piranha.permissions.load(function () {
                // Get Page Header
                fetch(piranha.baseUrl + "manager/contactdetails/save", {
                    method: "post",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(model)
                })
                    .then(function (response) { return response.json(); })
                    .then(function (result) {
                        piranha.notifications.push(result.status);
                    })
                    .catch(function (error) { console.log("error:", error); });
            });
        },
        selectProfileImage: function () {
            if (this.detailsModel.profile.image != null && this.detailsModel.profile.image.media !== null) {
                piranha.mediapicker.open(this.updatePrimaryImage, "Image", this.detailsModel.profile.image.media.folderId);
            } else {
                piranha.mediapicker.openCurrentFolder(this.updatePrimaryImage, "Image");
            }
        },
        updatePrimaryImage: function (media) {
            if (media.type === "Image") {
                if (this.detailsModel.profile.image == null) {
                    this.detailsModel.profile.image = media;
                }
                else {
                    this.detailsModel.profile.image.id = media.id;
                    this.detailsModel.profile.image.media = media;
                }

            } else {
                console.log("No image was selected");
            }
        },
        load: function () {
            var self = this;
            piranha.permissions.load(function () {
                // Get Page Header
                fetch(piranha.baseUrl + "manager/contactdetails/load")
                    .then(function (response) { return response.json(); })
                    .then(function (result) {
                        self.bindContactDetailsModel(result);
                        self.loading = false;
                    })
                    .catch(function (error) { console.log("error:", error); });
            });
        }
    }
});
