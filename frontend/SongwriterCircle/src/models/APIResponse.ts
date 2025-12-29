export type APIResponse<T> = {
    sucess: boolean
    content: T;
    status?: number;
}