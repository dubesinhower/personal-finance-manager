export class EmailAccount {
    constructor(
        public id: number,
        public name: string,
        public type: any,
        public created: Date,
        public lastScanned: Date
    ) { }
}

export class ImapAccount extends EmailAccount{
    constructor(
        public id: number,
        public name: string,
        public type: any,
        public created: Date,
        public lastScanned: Date,
        public imapCredentials: boolean
    ) { super(id, name, type, created, lastScanned); }
}
