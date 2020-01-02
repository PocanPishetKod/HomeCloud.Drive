export class DirectoryDescryptorRouteDescryptor {
  private baseRoute: string = "api/directories";

  public getManyRoute(parentDirectoryDescryptorId?: number): string {
    if (parentDirectoryDescryptorId) {
      return this.baseRoute + "/" + parentDirectoryDescryptorId;
    }

    return this.baseRoute;
  }

  public getSaveRoute(): string {
    return this.baseRoute;
  }

  public getDeleteRoute(directoryDescryptorId: number): string {
    return this.baseRoute + "/" + directoryDescryptorId; 
  }
}

export class FileDescryptorRouteDescryptor {
  private baseRoute: string = "api/files";

  public getManyRoute(directoryDescryptorId?: number): string {
    if (directoryDescryptorId) {
      return this.baseRoute + "/" + directoryDescryptorId;
    }

    return this.baseRoute;
  }

  public getSaveRoute(): string {
    return this.baseRoute;
  }

  public getDownloadRoute(fileDescryptorId: number): string {
    return this.baseRoute + "/" + fileDescryptorId + "/download";
  }

  public getUploadRoute(): string {
    return this.baseRoute + "/upload";
  }

  public getDeleteRoute(fileDescryptorId: number): string {
    return this.baseRoute + "/" + fileDescryptorId;
  }
}
