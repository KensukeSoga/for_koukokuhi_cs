package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HM請求書(CR制作費)取得検索DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillCreateDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindHMBillCreateCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindHMBillCreateDAO() {
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
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj07EstimateCreate.ESTDETAILSEQNO
                ,Tbj07EstimateCreate.DCARCD
                ,Tbj07EstimateCreate.PHASE
                ,Tbj07EstimateCreate.CRDATE
                ,Tbj07EstimateCreate.SEQUENCENO
                ,Tbj07EstimateCreate.CLASSDIV
                ,Tbj07EstimateCreate.SORTNO
                ,Tbj07EstimateCreate.CLASSCD
                ,Tbj07EstimateCreate.EXPCD
                ,Tbj07EstimateCreate.EXPENSE
                ,Tbj07EstimateCreate.DETAIL
                ,Tbj07EstimateCreate.KIKANS
                ,Tbj07EstimateCreate.KIKANE
                ,Tbj07EstimateCreate.CONTRACTDATE
                ,Tbj07EstimateCreate.CONTRACTTERM
                ,Tbj07EstimateCreate.SEIKYU
                ,Tbj07EstimateCreate.ORDERNO
                ,Tbj07EstimateCreate.PAY
                ,Tbj07EstimateCreate.USERNAME
                ,Tbj07EstimateCreate.GETMONEY
                ,Tbj07EstimateCreate.GETCONF
                ,Tbj07EstimateCreate.PAYMONEY
                ,Tbj07EstimateCreate.PAYCONF
                ,Tbj07EstimateCreate.ESTMONEY
                ,Tbj07EstimateCreate.CLMMONEY
                ,Tbj07EstimateCreate.DELIVERDAY
                ,Tbj07EstimateCreate.SETMONTH
                ,Tbj07EstimateCreate.DIVCD
                ,Tbj07EstimateCreate.GROUPCD
                ,Tbj07EstimateCreate.STKYKNO
                ,Tbj07EstimateCreate.EGTYKFLG
                ,Tbj07EstimateCreate.INPUTTNTCD
                ,Tbj07EstimateCreate.NOTE
                ,Tbj07EstimateCreate.CLASSCDFLG
                ,Tbj07EstimateCreate.EXPCDFLG
                ,Tbj07EstimateCreate.EXPENSEFLG
                ,Tbj07EstimateCreate.DETAILFLG
                ,Tbj07EstimateCreate.KIKANSFLG
                ,Tbj07EstimateCreate.KIKANEFLG
                ,Tbj07EstimateCreate.CONTRACTDATEFLG
                ,Tbj07EstimateCreate.CONTRACTTERMFLG
                ,Tbj07EstimateCreate.SEIKYUFLG
                ,Tbj07EstimateCreate.ORDERNOFLG
                ,Tbj07EstimateCreate.PAYFLG
                ,Tbj07EstimateCreate.USERNAMEFLG
                ,Tbj07EstimateCreate.GETMONEYFLG
                ,Tbj07EstimateCreate.PAYMONEYFLG
                ,Tbj07EstimateCreate.ESTMONEYFLG
                ,Tbj07EstimateCreate.CLMMONEYFLG
                ,Tbj07EstimateCreate.DELIVERDAYFLG
                ,Tbj07EstimateCreate.SETMONTHFLG
                ,Tbj07EstimateCreate.DIVISIONFLG
                ,Tbj07EstimateCreate.GROUPCDFLG
                ,Tbj07EstimateCreate.STKYKNOFLG
                ,Tbj07EstimateCreate.INPUTTNTCDFLG
                ,Tbj07EstimateCreate.NOTEFLG
                ,Tbj07EstimateCreate.CRTDATE
                ,Tbj07EstimateCreate.CRTNM
                ,Tbj07EstimateCreate.CRTAPL
                ,Tbj07EstimateCreate.CRTID
                ,Tbj07EstimateCreate.UPDDATE
                ,Tbj07EstimateCreate.UPDNM
                ,Tbj07EstimateCreate.UPDAPL
                ,Tbj07EstimateCreate.UPDID
                ,Tbj07EstimateCreate.GETTIME
                ,Tbj07EstimateCreate.TIMSTMPSS
                ,Tbj07EstimateCreate.UPDAPLSS
                ,Tbj07EstimateCreate.UPDIDSS
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return Tbj07EstimateCreate.TBNAME;
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

        sql.append(" SELECT ");

        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }

        sql.append(" FROM ");
        sql.append(getTableName());

        if (_condition.getEstSeqNoList().size() > 0) {
            sql.append(" WHERE ");
            sql.append(Tbj07EstimateCreate.ESTDETAILSEQNO);
            sql.append(" IN (");

            for (int i = 0; i < _condition.getEstSeqNoList().size(); i++) {
                sql.append(_condition.getEstSeqNoList().get(i));

                if (i < _condition.getEstSeqNoList().size() - 1) {
                    sql.append(", ");
                }
            }

            sql.append(")");
        }

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHMBillCreateVO> selectVO(FindHMBillCreateCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHMBillCreateVO());
        try
        {
            _condition = condition;
            return (List<FindHMBillCreateVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
