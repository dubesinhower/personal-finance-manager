export class EmailAccount {
    constructor(
        public id: number,
        public name: string,
        public type: any
    ) { }
}

export class ImapAccount extends EmailAccount{
    constructor(
        public id: number,
        public name: string,
        public type: any,
        public imapCredentials: boolean
    ) { super(id, name, type); }
}
