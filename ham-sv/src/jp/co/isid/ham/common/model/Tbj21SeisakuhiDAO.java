package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 制作費DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj21SeisakuhiDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj21SeisakuhiCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj21SeisakuhiDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj21Seisakuhi.PHASE
                ,Tbj21Seisakuhi.SEIKYUYM
                ,Tbj21Seisakuhi.DCARCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj21Seisakuhi.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj21Seisakuhi.CRTDATE
                ,Tbj21Seisakuhi.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj21Seisakuhi.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj21Seisakuhi.PHASE
                ,Tbj21Seisakuhi.SEIKYUYM
                ,Tbj21Seisakuhi.DCARCD
                ,Tbj21Seisakuhi.DCARNM
                ,Tbj21Seisakuhi.SEISAKUHIH
                ,Tbj21Seisakuhi.SEISAKUHIS
                ,Tbj21Seisakuhi.SEISAKUHIOTHER
                ,Tbj21Seisakuhi.BIKO
                ,Tbj21Seisakuhi.GETTIME
                ,Tbj21Seisakuhi.CRTDATE
                ,Tbj21Seisakuhi.CRTNM
                ,Tbj21Seisakuhi.CRTAPL
                ,Tbj21Seisakuhi.CRTID
                ,Tbj21Seisakuhi.UPDDATE
                ,Tbj21Seisakuhi.UPDNM
                ,Tbj21Seisakuhi.UPDAPL
                ,Tbj21Seisakuhi.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {
        StringBuffer sql = new StringBuffer();

        sql.append("DELETE FROM ");
        sql.append(Tbj21Seisakuhi.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj21Seisakuhi.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj21Seisakuhi.SEIKYUYM);
        sql.append(" = ");
        sql.append(getDBModelInterface().ConvertToDBString(_condition.getSeikyuym()));

        return sql.toString();
    }

    /**
     * 制作費を削除します
     * @param condition 削除条件
     * @throws HAMException
     */
    public void deleteSeisakuhi(Tbj21SeisakuhiCondition condition) throws HAMException {
        try {
            _condition = condition;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 登録
     * @param vo 登録データ
     * @throws HAMException
     */
    public void insertVo(Tbj21SeisakuhiVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}
