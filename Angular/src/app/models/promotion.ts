export class Promotion {
    constructor(
        public promotionId?:number,
        public code?:string,
        public description?:string,
        public discount?:number,
        public startDate?:Date,
        public endDate?:Date,
        public remainingUses?:number
    ){}
}
