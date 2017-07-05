app.controller('productCtrl',
    function ($scope, $http) {

        $scope.getProducts = function () {
            $http({
                method: "GET",
                url: "/admin/Product/Index"
            }).then(function (result) {
                $scope.products = result.data;
            }, function (result) {
                console.log(result);
            });
        }

        $scope.selectProduct = function (product) {
            $scope.selectedProduct = product;
            $scope.getColors();
            $scope.getCheckBoxDatas();
            $scope.getSubCategoriesByCategoryID(product.CategoryID);
        }

        $scope.selectProductDetail = function (product) {
            $scope.selectedProductDetail = product;
            $scope.getColors();
            $scope.getCheckBoxDatas();
            $scope.getSubCategoriesByCategoryID(product.CategoryID);
        }

        $scope.selectImage = function (image) {
            $scope.selectedImage = image;
        }

        $scope.addImage = function (newImage) {
            newImage.ProductDetailID = $scope.selectedProductDetail.ProductDetailID;
            $http({
                method: "POST",
                url: "/admin/Image/Add",
                data: newImage
            }).then(function (result) {
                $scope.getProducts();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.deleteImage = function (image) {
            $http({
                method: "POST",
                url: "/admin/Image/Delete",
                data: image
            }).then(function (result) {
                $scope.getProducts();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.editImage = function (image) {
            $http({
                method: "POST",
                url: "/admin/Image/Edit",
                data: image
            }).then(function (result) {
                $scope.getProducts();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.getCheckBoxDatas = function() {
            $scope.getCategories();
            $scope.getBrands();
            $scope.getSuppliers();
        }

        $scope.getCategories = function() {
            $http({
                method: "GET",
                url: "/admin/Category/Index"
            }).then(function (result) {
                $scope.categories = result.data;
            }, function (result) {
                console.log(result);
            });
        }

        $scope.getSubCategoriesByCategoryID = function (categoryID) {
            $http({
                method: "GET",
                url: "/admin/SubCategory/GetSubCategoriesByCategoryID",
                params: {id: categoryID}
            }).then(function (result) {
                $scope.subCategories = result.data;
            }, function (result) {
                console.log(result);
            });
        }

        $scope.getBrands = function () {
            $http({
                method: "GET",
                url: "/admin/Brand/Index"
            }).then(function (result) {
                $scope.brands = result.data;
            }, function (result) {
                console.log(result);
            });
        }

        $scope.getSuppliers = function () {
            $http({
                method: "GET",
                url: "/admin/Company/Index"
            }).then(function (result) {
                $scope.suppliers = result.data;
            }, function (result) {
                console.log(result);
            });
        }

        $scope.addProduct = function (product) {
            console.log();
            $http({
                method: "POST",
                url: "/admin/Product/Add",
                data: product
            }).then(function (result) {
                $scope.getProducts();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.deleteProduct = function (product) {
            console.log();
            $http({
                method: "POST",
                url: "/admin/Product/Delete",
                data: product
            }).then(function (result) {
                $scope.getProducts();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.updateProduct = function (product) {
            console.log();
            $http({
                method: "POST",
                url: "/admin/Product/Edit",
                data: product
            }).then(function (result) {
                $scope.getProducts();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.addProductDetail = function (productDetail) {
            console.log();
            productDetail.ProductID = $scope.selectedProduct.ProductID;
            $http({
                method: "POST",
                url: "/admin/ProductDetail/Add",
                data: productDetail
            }).then(function (result) {
                $scope.getProducts();
                $scope.selectedProduct = null;
            }, function (result) {
                console.log(result);
            });
        }

        $scope.editProductDetail = function (productDetail) {
            console.log();
            productDetail.ProductID = $scope.selectedProduct.ProductID;
            $http({
                method: "POST",
                url: "/admin/ProductDetail/Edit",
                data: productDetail
            }).then(function (result) {
                $scope.getProducts();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.deleteProductDetail = function (productDetail) {
            console.log();
            productDetail.ProductID = $scope.selectedProduct.ProductID;
            $http({
                method: "POST",
                url: "/admin/ProductDetail/Delete",
                data: productDetail
            }).then(function (result) {
                $scope.getProducts();
            }, function (result) {
                console.log(result);
            });
        }

        $scope.getColors = function () {
            $http({
                method: "GET",
                url: "/admin/Color/Index"
            }).then(function (result) {
                $scope.colors = result.data;
            }, function (result) {
                console.log(result);
            });
        };

        $scope.getProductDetailsByProductID = function (productID) {
            $http({
                method: "GET",
                url: "/admin/ProductDetail/GetProductDetailsByProductID",
                params: { productID: productID }
            }).then(function (result) {
                $scope.productDetails = result.data;
            }, function (result) {
                console.log(result);
            });
        }

        $scope.getProducts();
    })