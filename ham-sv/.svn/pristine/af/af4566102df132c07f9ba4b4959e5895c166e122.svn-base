package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
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
* 送稿表の情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/9/20 Fujiyoshi)<BR>
* </P>
*
* @author Fujiyoshi
*/
public class FindDocumentTransmissionDAO extends AbstractRdbDao {

    private FindDocumentTransmissionCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindDocumentTransmissionDAO() {
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
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append(Tbj02EigyoDaicho.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj05Car.TBNAME);
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

        sql.append("SELECT ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(", ");
        sql.append("MIN(");
        sql.append(Mbj05Car.CARNM);
        sql.append(") AS ");
        sql.append(Mbj05Car.CARNM);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.CAMPAIGN);
        sql.append(", ");
        sql.append("MIN(");
        sql.append(Tbj02EigyoDaicho.KIKANFROM);
        sql.append(") AS TERMSTART");
        sql.append(", ");
        sql.append("MAX(");
        sql.append(Tbj02EigyoDaicho.KIKANFROM);
        sql.append(") AS TERMEND");

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
        sql.append(Tbj02EigyoDaicho.CAMPAIGN);
        sql.append(" IS NOT NULL");

        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(" = ");
        sql.append(Mbj05Car.DCARCD);

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
        sql.append(" EXISTS(");
        sql.append(" SELECT 'X'");
        sql.append(" FROM ");
        sql.append(Mbj47Newspaper.TBNAME);
        sql.append(" WHERE ");
        sql.append(Mbj47Newspaper.NPCD);
        sql.append(" = ");
        sql.append(Tbj02EigyoDaicho.MEDIASCD);
        sql.append(")");

        sql.append(" GROUP BY ");
        sql.append(Tbj02EigyoDaicho.DCARCD);
        sql.append(", ");
        sql.append(Tbj02EigyoDaicho.CAMPAIGN);

        sql.append(" ORDER BY ");
        sql.append("MIN(");
        sql.append(Tbj02EigyoDaicho.SORTNO);
        sql.append(")");

        return sql.toString();
    }


    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindDocumentTransmissionVO> selectVO(FindDocumentTransmissionCondition condition) throws HAMException {

        super.setModel(new FindDocumentTransmissionVO());
        try
        {
            _condition = condition;
            return (List<FindDocumentTransmissionVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
