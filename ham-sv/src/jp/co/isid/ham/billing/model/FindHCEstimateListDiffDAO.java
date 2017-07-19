package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HC見積一覧変更確認データ取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/7 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListDiffDAO extends AbstractRdbDao {

    FindHCEstimateListDiffCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCEstimateListDiffDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
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
                Tbj05EstimateItem.PHASE,
                Tbj05EstimateItem.CRDATE,
                Tbj05EstimateItem.ESTSEQNO,
                Tbj06EstimateDetail.ESTDETAILSEQNO,
                Tbj22SeisakuhiSs.SEQUENCENO,
                Tbj07EstimateCreate.DCARCD,
                Tbj22SeisakuhiSs.DCARCD,
                Tbj07EstimateCreate.CRDATE,
                Tbj22SeisakuhiSs.CRDATE,
                Tbj07EstimateCreate.CLASSDIV,
                Tbj22SeisakuhiSs.CLASSDIV,
                Tbj07EstimateCreate.CLASSCD,
                Tbj22SeisakuhiSs.CLASSCD,
                Tbj07EstimateCreate.EXPCD,
                Tbj22SeisakuhiSs.EXPCD,
                Tbj07EstimateCreate.EXPENSE,
                Tbj22SeisakuhiSs.EXPENSE,
                Tbj07EstimateCreate.ESTMONEY,
                Tbj22SeisakuhiSs.ESTMONEY,
                Tbj07EstimateCreate.CLMMONEY,
                Tbj22SeisakuhiSs.CLMMONEY,
                Tbj07EstimateCreate.DIVCD,
                Tbj22SeisakuhiSs.DIVCD,
                Tbj07EstimateCreate.GROUPCD,
                Tbj22SeisakuhiSs.GROUPCD,
                Tbj07EstimateCreate.KIKANS,
                Tbj22SeisakuhiSs.KIKANS,
                Tbj07EstimateCreate.KIKANE,
                Tbj22SeisakuhiSs.KIKANE,
                Tbj07EstimateCreate.DELIVERDAY,
                Tbj22SeisakuhiSs.DELIVERDAY,
                Tbj07EstimateCreate.SETMONTH,
                Tbj22SeisakuhiSs.SETMONTH,
                Tbj07EstimateCreate.STKYKNO,
                Tbj22SeisakuhiSs.STKYKNO,
                "EST." + Mbj29SetteiKyk.STKYKNM + " ESTSTKYKNM",
                "CPT." + Mbj29SetteiKyk.STKYKNM + " CPTSTKYKNM",
                Tbj07EstimateCreate.EGTYKFLG,
                Tbj22SeisakuhiSs.EGTYKFLG,
                Tbj07EstimateCreate.INPUTTNTCD,
                Tbj22SeisakuhiSs.INPUTTNTCD,
                "EST." + Mbj30InputTnt.INPUTTNT + " ESTINPUTTNT",
                "CPT." + Mbj30InputTnt.INPUTTNT + " CPTINPUTTNT"
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append(Tbj05EstimateItem.TBNAME);
        tbl.append(", ");
        tbl.append(Tbj06EstimateDetail.TBNAME);
        tbl.append(", ");
        tbl.append(Tbj07EstimateCreate.TBNAME);
        tbl.append(", ");
        tbl.append(Tbj22SeisakuhiSs.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj29SetteiKyk.TBNAME);
        tbl.append(" EST");
        tbl.append(", ");
        tbl.append(Mbj29SetteiKyk.TBNAME);
        tbl.append(" CPT");
        tbl.append(", ");
        tbl.append(Mbj30InputTnt.TBNAME);
        tbl.append(" EST");
        tbl.append(", ");
        tbl.append(Mbj30InputTnt.TBNAME);
        tbl.append(" CPT");

        return tbl.toString();
    }

    /**
     * 更新日付フィールドを取得する
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
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }
        sql.append(" FROM ");
        sql.append(getTableName());
        sql.append(" WHERE ");
        sql.append(Tbj05EstimateItem.PHASE);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.PHASE);
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.CRDATE);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.CRDATE);
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.ESTSEQNO);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.ESTSEQNO);
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.ESTDETAILSEQNO);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.ESTDETAILSEQNO);
        sql.append(" AND ");
        sql.append(Tbj07EstimateCreate.SEQUENCENO);
        sql.append(" = ");
        sql.append(Tbj22SeisakuhiSs.SEQUENCENO);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append("EST.");
        sql.append(Mbj29SetteiKyk.PHASE);
        sql.append("(+)");
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj07EstimateCreate.STKYKNO);
        sql.append(" = ");
        sql.append("EST.");
        sql.append(Mbj29SetteiKyk.STKYKNO);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append("CPT.");
        sql.append(Mbj29SetteiKyk.PHASE);
        sql.append("(+)");
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.STKYKNO);
        sql.append(" = ");
        sql.append("CPT.");
        sql.append(Mbj29SetteiKyk.STKYKNO);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append("EST.");
        sql.append(Mbj30InputTnt.PHASE);
        sql.append("(+)");
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj07EstimateCreate.CLASSDIV);
        sql.append(" = ");
        sql.append("EST.");
        sql.append(Mbj30InputTnt.CLASSDIV);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj07EstimateCreate.INPUTTNTCD);
        sql.append(" = ");
        sql.append("EST.");
        sql.append(Mbj30InputTnt.SEQNO);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj07EstimateCreate.DCARCD);
        sql.append(" = ");
        sql.append("EST.");
        sql.append(Mbj30InputTnt.DCARCD);
        sql.append("(+)");

        sql.append(" AND ");
        sql.append("CPT.");
        sql.append(Mbj30InputTnt.PHASE);
        sql.append("(+)");
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CLASSDIV);
        sql.append(" = ");
        sql.append("CPT.");
        sql.append(Mbj30InputTnt.CLASSDIV);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.INPUTTNTCD);
        sql.append(" = ");
        sql.append("CPT.");
        sql.append(Mbj30InputTnt.SEQNO);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" = ");
        sql.append("CPT.");
        sql.append(Mbj30InputTnt.DCARCD);
        sql.append("(+)");

        if (_condition.getEstSeqNoList().size() > 0) {
            sql.append(" AND ");
            sql.append(Tbj05EstimateItem.ESTSEQNO);
            sql.append(" IN (");

            for (int i = 0; i < _condition.getEstSeqNoList().size(); i++) {
                sql.append(_condition.getEstSeqNoList().get(i));
                if (i<_condition.getEstSeqNoList().size()-1) {
                    sql.append(", ");
                }
            }

            sql.append(")");
        }

        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.CRDATE);
        sql.append(" = TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM')");
        sql.append(" ORDER BY ");
        sql.append(Tbj07EstimateCreate.SEQUENCENO);
        sql.append(", ");
        sql.append(Tbj22SeisakuhiSs.GETTIME);
        sql.append(" DESC");

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHCEstimateListDiffVO> selectVO(FindHCEstimateListDiffCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHCEstimateListDiffVO());
        try
        {
            _condition = condition;
            return (List<FindHCEstimateListDiffVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
