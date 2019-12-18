export interface iStatusState {
    id: string;
    dateStamp: Date;
    state: iState;
}
export interface iState{
    systemCode: number,
    isSorryOn: boolean
}