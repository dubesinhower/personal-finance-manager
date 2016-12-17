export class EmailAccount {
    constructor(
        public id: number,
        public name: string,
        public type: any,
        public createDate: Date,
        public lastScanDate: Date
    ) { }
}

export class ImapAccount extends EmailAccount{
    constructor(
        public id: number,
        public name: string,
        public type: any,
        public createDate: Date,
        public lastScanDate: Date,
        public imapCredentials: boolean
    ) { super(id, name, type, createDate, lastScanDate); }
}
