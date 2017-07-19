package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 入力担当マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
public class Mbj30InputTntDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj30InputTntCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        LOAD, VO, MAXSEQ, MAXSORT
    };

    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj30InputTntDAO() {
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
        return new String[] { Mbj30InputTnt.PHASE, Mbj30InputTnt.CLASSDIV, Mbj30InputTnt.SEQNO };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj30InputTnt.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj30InputTnt.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj30InputTnt.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj30InputTnt.PHASE,
                Mbj30InputTnt.CLASSDIV,
                Mbj30InputTnt.SEQNO,
                Mbj30InputTnt.DCARCD,
                Mbj30InputTnt.INPUTTNT,
                Mbj30InputTnt.SORTNO,
                Mbj30InputTnt.UPDDATE,
                Mbj30InputTnt.UPDNM,
                Mbj30InputTnt.UPDAPL,
                Mbj30InputTnt.UPDID };
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();
        StringBuffer orderSql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            // *******************************************
            // Load()で使用されるSELECT + FROM句のSQL
            // *******************************************
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] + " ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.VO)) {

            // *******************************************
            // selectVOで使用されるSQL
            // *******************************************
            // SELECT + FROM句
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] + " ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");
            // WHERE句
            if (_condition != null)
            {
                Mbj30InputTntVO vo = new Mbj30InputTntVO();
                vo.setPHASE(_condition.getPhase());
                vo.setCLASSDIV(_condition.getClassdiv());
                vo.setSEQNO(_condition.getSeqno());
                vo.setDCARCD(_condition.getDcarcd());
                vo.setINPUTTNT(_condition.getInputtnt());
                vo.setSORTNO(_condition.getSortno());
                vo.setUPDDATE(_condition.getUpddate());
                vo.setUPDNM(_condition.getUpdnm());
                vo.setUPDAPL(_condition.getUpdapl());
                vo.setUPDID(_condition.getUpdid());

                whereSql.append(generateWhereByCond(vo));

            }

            orderSql.append(" ORDER BY ");
            orderSql.append(" " + Mbj30InputTnt.SORTNO + "," + Mbj30InputTnt.SEQNO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXSEQ)) {

            //*******************************************
            //findMaxSeqNoで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            selectSql.append(" SELECT ");
            selectSql.append("     NVL(MAX(" + Mbj30InputTnt.SEQNO  + "), 0) AS " + Mbj30InputTnt.SEQNO + " ");
            selectSql.append(" FROM ");
            selectSql.append(" " + Mbj30InputTnt.TBNAME + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXSORT)) {

            //*******************************************
            //findMaxSortNoで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            selectSql.append(" SELECT ");
            selectSql.append("     NVL(MAX(" + Mbj30InputTnt.SORTNO  + "), 0) AS " + Mbj30InputTnt.SORTNO + " ");
            selectSql.append(" FROM ");
            selectSql.append(" " + Mbj30InputTnt.TBNAME + " ");
            selectSql.append(" WHERE ");
            selectSql.append("     " + Mbj30InputTnt.PHASE + " = " + getDBModelInterface().ConvertToDBString(_condition.getPhase()));
            selectSql.append(" AND " + Mbj30InputTnt.CLASSDIV + " = " + getDBModelInterface().ConvertToDBString(_condition.getClassdiv()));
        }

        return selectSql.toString() + whereSql.toString() + orderSql.toString();
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     *
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                }
                else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj30InputTntVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try
        {
            if (!super.insert())
            {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Mbj30InputTntVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try
        {
            if (!super.update())
            {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }

    }

    /**
     * DeleteVO
     * @param vo データ
     * @throws HAMException
     */
    public void deleteVO(Mbj30InputTntVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);

        try
        {
            if (!super.remove())
            {
                throw new HAMException("削除エラー", "BJ-E0004");
            }
        }
        catch(ConcurrentUpdateException e)
        {   // 処理件数「0」の場合
            return;   // 正常とする（削除レコードなし）
        }
        catch(UpdateFailureException e)
        {   // 処理件数「2以上」の場合
            return;   // 正常とする
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }

    }

    /**
     * 指定した条件で検索を行い、データを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj30InputTntVO> selectVO(Mbj30InputTntCondition condition) throws HAMException {

        super.setModel(new Mbj30InputTntVO());
        try {
            _SelSqlMode = SelSqlMode.VO;
            _condition = condition;
            return (List<Mbj30InputTntVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SEQNOのMAX値を取得します
     *
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj30InputTntVO> findMaxSeqNo(/*Mbj30InputTntCondition condition*/) throws HAMException {

        super.setModel(new Mbj30InputTntVO());
        try {
            _SelSqlMode = SelSqlMode.MAXSEQ;
            //_condition = condition;
            return (List<Mbj30InputTntVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SORTNOのMAX値を取得します
     *
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj30InputTntVO> findMaxSortNo(Mbj30InputTntCondition condition) throws HAMException {

        super.setModel(new Mbj30InputTntVO());
        try {
            _SelSqlMode = SelSqlMode.MAXSORT;
            _condition = condition;
            return (List<Mbj30InputTntVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
