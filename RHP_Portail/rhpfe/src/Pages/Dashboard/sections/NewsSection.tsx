import { SchoolOutlined, Newspaper } from "@mui/icons-material";
import { Box, Card, CardContent, CardMedia, Chip, Paper, Stack, Typography } from "@mui/material";
import { colorBase } from "../../../modules/module_general";
import type { NewsSectionProps } from "./SectionTypes";

const extractFirstImage = (html: string) => {
  if (!html) return null;
  const match = html.match(/<img[^>]+src\s*=\s*["']([^"']+)["']/i);
  return match ? match[1] : null;
};

const NewsSection = ({ blogs, formatDate, onNavigate }: NewsSectionProps) => {
  return (
    <Box>
      <Stack direction="row" alignItems="center" spacing={1} sx={{ mb: 2, mt: 2, justifyContent: { xs: "center", sm: "flex-start" } }}>
        <Newspaper sx={{ fontSize: 22, color: colorBase.colorBase01 }} />
        <Typography variant="h6" fontWeight="bold" sx={{ color: colorBase.colorBase01 }}>
          Actualités RH
        </Typography>
      </Stack>
      <Box sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
        {blogs.length === 0 ? (
          <Box>
            <Typography variant="body2" color="text.secondary">Aucune actualité pour le moment.</Typography>
          </Box>
        ) : (
          blogs.map((blog: any) => {
            const imageUrl = extractFirstImage(blog.Contenus);
            const handleClick = () => onNavigate(`/myspace/Communication_Blog/Blog/${blog.Num_Blog}`);

            return (
              <Box key={blog.Num_Blog}>
                {imageUrl ? (
                  <Card
                    sx={{
                      borderRadius: 2,
                      display: "flex",
                      flexDirection: { xs: "column", sm: "row" },
                      cursor: "pointer",
                      border: "1px solid rgba(0,0,0,0.06)",
                      boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
                      overflow: "hidden",
                      transition: "box-shadow 0.15s",
                      "&:hover": { boxShadow: "0 4px 12px rgba(0,0,0,0.08)" },
                    }}
                    onClick={handleClick}
                  >
                    <CardMedia
                      component="img"
                      sx={{
                        width: { xs: "100%", sm: 160, md: 180 },
                        height: { xs: 140, sm: "auto" },
                        minHeight: { sm: 110 },
                        objectFit: "cover",
                        objectPosition: "top center",
                      }}
                      image={imageUrl}
                      alt={blog.Titre_Blog}
                    />
                    <CardContent sx={{ p: 2, flex: 1, display: "flex", flexDirection: "column", justifyContent: "center" }}>
                      <Typography variant="body1" fontWeight="600" color="text.primary" sx={{ mb: 0.5, lineHeight: 1.4 }}>
                        {blog.Titre_Blog}
                      </Typography>
                      <Stack direction="row" justifyContent="space-between" alignItems="center" spacing={1}>
                        <Typography variant="caption" color="text.secondary">{formatDate(blog.Dat_Crea)}</Typography>
                        <Chip label={blog.Categorie || "Info"} size="small" color="primary" variant="outlined" />
                      </Stack>
                    </CardContent>
                  </Card>
                ) : (
                  <Paper
                    sx={{
                      borderRadius: 2,
                      border: "1px solid rgba(0,0,0,0.06)",
                      boxShadow: "0 1px 3px rgba(0,0,0,0.06)",
                      cursor: "pointer",
                      display: "flex",
                      flexDirection: { xs: "column", sm: "row" },
                      alignItems: { sm: "center" },
                      overflow: "hidden",
                      transition: "box-shadow 0.15s",
                      "&:hover": { boxShadow: "0 4px 12px rgba(0,0,0,0.08)" },
                    }}
                    onClick={handleClick}
                  >
                    <Box
                      sx={{
                        width: { xs: "100%", sm: 160, md: 180 },
                        minHeight: { xs: 80, sm: 110 },
                        display: "flex",
                        alignItems: "center",
                        justifyContent: "center",
                        bgcolor: `${colorBase.colorBase01}12`,
                        color: colorBase.colorBase01,
                      }}
                    >
                      <SchoolOutlined fontSize="large" />
                    </Box>
                    <Box sx={{ p: 2, flex: 1 }}>
                      <Typography variant="body1" fontWeight="600" color="text.primary" sx={{ mb: 0.5, lineHeight: 1.4 }}>
                        {blog.Titre_Blog}
                      </Typography>
                      <Typography variant="caption" color="text.secondary">{formatDate(blog.Dat_Crea)}</Typography>
                      <Chip label={blog.Categorie || "Info"} size="small" sx={{ ml: 1, bgcolor: "rgba(0,0,0,0.06)", color: "text.secondary" }} />
                    </Box>
                  </Paper>
                )}
              </Box>
            );
          })
        )}
      </Box>
    </Box>
  );
};

export default NewsSection;
