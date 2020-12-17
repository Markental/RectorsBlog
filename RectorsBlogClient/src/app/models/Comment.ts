export interface Comment {
    commentId: number;
    content: string;
    authorId: number;
    authorName: string;
    postId: number;
    creationDate: Date;
}