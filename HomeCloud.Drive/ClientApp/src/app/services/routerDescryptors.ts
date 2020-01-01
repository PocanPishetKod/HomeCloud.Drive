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
}
