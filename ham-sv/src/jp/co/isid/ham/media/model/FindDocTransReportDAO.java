package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj47Newspaper;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
*
* <P>
* 送稿表の帳票出力情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/9/26 Fujiyoshi)<BR>
* </P>
*
* @author Fujiyoshi
*/
public class FindDocTransReportDAO extends AbstractRdbDao {

    FindDocTransReportCondition _condition = null;
    int _counter = 0;

    /**
     * デフォルトコンストラクタ
     */
    public FindDocTransReportDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                getNameSQL(Mbj47Newspaper.RNAME, Mbj47Newspaper.RNAME)
                ,getNameSQL(Mbj47Newspaper.AREA, Mbj47Newspaper.AREA)
                ,getNameSQL(Mbj12Code.CODENAME, "NPDIVISIONNM")
                ,Tbj02EigyoDaicho.PUBLISHVER
                ,Tbj02EigyoDaicho.NAIYOHIMOKU
                ,Tbj02EigyoDaicho.SPACE
                ,Tbj02EigyoDaicho.KIKANFROM
                ,Tbj02EigyoDaicho.DCARCD
                ,Tbj02EigyoDaicho.CAMPAIGN
                ,Tbj02EigyoDaicho.MEDIASCD
        };
    }

    /**
     * 名称取得SQLを返します
     *
     * @param colName カラム名
     * @return SQL文
     */
    private String getNameSQL(String colName, String newColName) {
        StringBuilder sql = new StringBuilder();

        sql.append("MIN(");
        sql.append(colName);
        sql.append(") AS ");
        sql.append(newColName);

        return sql.toString();
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        StringBuilder tbl = new StringBuilder();

        tbl.append(Tbj02EigyoDaicho.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj47Newspaper.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj12Code.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj10MediaSec.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj11CarSec.TBNAME);

        return tbl.toString();
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }


    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        for (int i = 0;i < getTableColumnNames().length;i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length -1) {
                sql.append(",");
            }
        }

        sql.append(" FROM ");
        sql.append(getTableName());

        sql.append(" WHERE ");
        sql.append(Tbj02EigyoDaicho.MEDIACD);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMediaCd());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.KIKANFROM);
        sql.append(" >= ");
        sql.append(getDBModelInterface().ConvertToDBString(_condition.getTermStart()));
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.KIKANFROM);
        sql.append(" <= ");
        sql.append(getDBModelInterface().ConvertToDBString(_condition.getTermEnd()));
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getDcarcd().get(_counter));
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.CAMPAIGN);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getCampaign().get(_counter));
        sql.append("'");

        sql.append(" AND ");
        sql.append(Mbj10MediaSec.HAMID);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getHamId());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.MEDIACD);
        sql.append(" = ");
        sql.append(Mbj10MediaSec.MEDIACD);
        sql.append(" AND ");
        sql.append(Mbj10MediaSec.AUTHORITY);
        sql.append(" > 0");

        sql.append(" AND ");
        sql.append(Mbj11CarSec.SECTYPE);
        sql.append(" = ");
        sql.append("'0'");
        sql.append(" AND ");
        sql.append(Mbj11CarSec.HAMID);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getHamId());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(" = ");
        sql.append(Mbj11CarSec.DCARCD);
        sql.append(" AND ");
        sql.append(Mbj11CarSec.AUTHORITY);
        sql.append(" > 0");

        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.MEDIASCD);
        sql.append(" = ");
        sql.append(Mbj47Newspaper.NPCD);

        sql.append(" AND ");
        sql.append(Mbj12Code.CODETYPE);
        sql.append("(+)");
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getCodeTypeNp());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Mbj12Code.YOBI1);
        sql.append("(+)");
        sql.append(" = ");
        sql.append(Tbj02EigyoDaicho.NPDIVISION);

        sql.append(" GROUP BY ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.CAMPAIGN);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.MEDIASCD);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.NPDIVISION);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.PUBLISHVER);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.SPACE);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.NAIYOHIMOKU);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.KIKANFROM);

        sql.append(" ORDER BY ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.CAMPAIGN);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.MEDIASCD);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.NPDIVISION);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.PUBLISHVER);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.SPACE);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.NAIYOHIMOKU);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.KIKANFROM);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindDocTransReportVO> selectVO(FindDocTransReportCondition condition, int counter) throws HAMException {
        super.setModel(new FindDocTransReportVO());
        try
        {
            _condition = condition;
            _counter = counter;
            return (List<FindDocTransReportVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
