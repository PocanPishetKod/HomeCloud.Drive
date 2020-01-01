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
    return FileDescryptorRouteDescryptor;
}());
exports.FileDescryptorRouteDescryptor = FileDescryptorRouteDescryptor;
//# sourceMappingURL=routerDescryptors.js.map