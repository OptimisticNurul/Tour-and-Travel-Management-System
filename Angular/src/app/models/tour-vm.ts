import { TourAvailability } from "./tour-availability";
import { TourImage } from "./tour-image";

export class TourVM {
    constructor(
       public tourId?:number,
       public tourName?:string,
       public destination?:string,
       public duration?:number,
       public departureTime?:Date,
       public arrivalTime?:Date,
       public description?:string,
       public tourPackageId?:number,
       public tourImage?:TourImage[],
       public tourAvailabilities?:TourAvailability[],
       public imageFile?:File,
       public date?:Date,
       public availableSlots?:number
    ){}
}
