"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DirectoryDescryptorRouteDescryptor = /** @class */ (function () {
    function DirectoryDescryptorRouteDescryptor() {
        this.baseRoute = "api/directories";
    }
    DirectoryDescryptorRouteDescryptor.prototype.getManyRoute = function (parentDirectoryDescryptorId) {
        if (parentDirectoryDescryptorId) {
            return this.baseRoute + "/" + parentDirectoryDescryptorId;
        }
        return this.baseRoute;
    };
    DirectoryDescryptorRouteDescryptor.prototype.getSaveRoute = function () {
        return this.baseRoute;
    };
    DirectoryDescryptorRouteDescryptor.prototype.getDeleteRoute = function (directoryDescryptorId) {
        return this.baseRoute + "/" + directoryDescryptorId;
    };
    return DirectoryDescryptorRouteDescryptor;
}());
exports.DirectoryDescryptorRouteDescryptor = DirectoryDescryptorRouteDescryptor;
var FileDescryptorRouteDescryptor = /** @class */ (function () {
    function FileDescryptorRouteDescryptor() {
        this.baseRoute = "api/files";
    }
    FileDescryptorRouteDescryptor.prototype.getManyRoute = function (directoryDescryptorId) {
        if (directoryDescryptorId) {
            return this.baseRoute + "/" + directoryDescryptorId;
        }
        return this.baseRoute;
    };
    FileDescryptorRouteDescryptor.prototype.getSaveRoute = function () {
        return this.baseRoute;
    };
    FileDescryptorRouteDescryptor.prototype.getDownloadRoute = function (fileDescryptorId) {
        return this.baseRoute + "/" + fileDescryptorId + "/download";
    };
    FileDescryptorRouteDescryptor.prototype.getUploadRoute = function () {
        return this.baseRoute + "/upload";
    };
    FileDescryptorRouteDescryptor.prototype.getDeleteRoute = function (fileDescryptorId) {
        return this.baseRoute + "/" + fileDescryptorId;
    };
    return FileDescryptorRouteDescryptor;
}());
exports.FileDescryptorRouteDescryptor = FileDescryptorRouteDescryptor;
//# sourceMappingURL=routerDescryptors.js.map