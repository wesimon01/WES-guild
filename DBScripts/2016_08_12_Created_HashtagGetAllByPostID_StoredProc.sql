create procedure HashtagGetByPostID
(
	@PostID int
) AS

select h.* from Hashtag h
join PostHash ph on ph.HashtagID = h.HashtagID
where ph.PostID = @PostID