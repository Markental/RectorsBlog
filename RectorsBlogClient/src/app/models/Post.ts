export interface Post {
    postId: number;
    title: string;
    summary: string;
    body: string;
    posterURL: string;
    userId: number;
    userName: string;
    creationDate: Date;
}