export class UserVM {
    constructor(
        public userId?:Number,
        public userName?:string,
        public password?:Number,
        public email?:string,
        public role?:string,
        public profileImage?:string,
        public imageFile?:File
    ){}
}
