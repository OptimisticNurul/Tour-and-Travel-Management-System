export class TourAvailability {
    constructor(
       public tourAvailabilityId?: number,
       public tourId?: number,
       public date?: Date,
       public availableSlots?:number 
    ){}
}
