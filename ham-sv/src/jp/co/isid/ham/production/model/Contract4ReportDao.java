package jp.co.isid.ham.production.model;

import java.util.ArrayList;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * タレント・ナレーター・楽曲契約表検索(帳票用)DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/03/26 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Contract4ReportDao extends AbstractRdbDao {

    ///** 電通車種コード - 株式会社あり */
    //private static final String DCAR_CD_KABU = "ZZZ";

    /**
     * SQLの種別を表す
     */
    private enum SQLType {
        /** 1つ目のSQL */
        FIRST("1"),

        /** 2つ目のSQL */
        SECOND("2");

        /** 種別 */
        private String _type;

        SQLType(String type) {
            _type = type;
        }

        /**
         * 種別を取得する.
         *
         * @return 種別
         */
        public String getType() {
            return _type;
        }
    }

    /**
     * 系統を表す
     */
    private enum TBJ18_NOKBN {
        /** タイム素材 */
        T("T+"),

        /** スポット素材 */
        S("S+"),

        /** ラジオ素材 */
        R("R+");

        /** 種別 */
        private String _type;

        TBJ18_NOKBN(String type) {
            _type = type;
        }

        /**
         * 種別を取得する.
         *
         * @return 種別
         */
        public String getType() {
            return _type;
        }
    }


    /** 検索条件 */
    private Contract4ReportCondition _condition = null;

    /**
     * コンストラクタ
     */
    public Contract4ReportDao() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    @Override
    public String getTableName() {
        return null;
    }

    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * 帳票出力するデータを検索する.
     *
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Contract4ReportVO> findReport(Contract4ReportCondition cond) throws HAMException {
        List<Contract4ReportVO> lstReturn = new ArrayList<Contract4ReportVO>();
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        setModel(new Contract4ReportVO());
        _condition = cond;
        try {
            lstReturn = find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }

        return lstReturn;
    }


    /**
     * デフォルトのSQL文を返す.
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        return createSql();
    }

    private String createSql() {
        StringBuilder sb = new StringBuilder();
        sb.append(createFirstPartOfSql());
        sb.append("UNION ALL ");
        sb.append(createSecondPartOfSql());
        sb.append(createOrderByPartOfSql());

        return sb.toString();
    }

    /**
     * 前半部分のSQLを作成する.
     *
     * @return SQL
     */
    private String createFirstPartOfSql() {
        StringBuilder sb = new StringBuilder();
        sb.append(createSelectPartOfSql(SQLType.FIRST));
        sb.append(createFromPartOfSql());
        sb.append(createWherePartOfFirstSql());
        sb.append(createGroupByPartOfSql());

        return sb.toString();
    }

    /**
     * 後半部分のSQLを作成する.
     *
     * @return SQL
     */
    private String createSecondPartOfSql() {
        StringBuilder sb = new StringBuilder();
        sb.append(createSelectPartOfSql(SQLType.SECOND));
        sb.append(createFromPartOfSql());
        sb.append(createWherePartOfSecondSql());
        sb.append(createGroupByPartOfSql());

        return sb.toString();
    }

    /**
     * SQLのうちSelect句の部分を作成する.
     * @param sortNo ソート順
     *
     * @return SQL
     */
    private String createSelectPartOfSql(SQLType sortNo) {
        StringBuilder sb = new StringBuilder();
        sb.append("SELECT ");
        sb.append(sortNo.getType() + " AS SORT_NO, ");
        //sb.append("CASE SUBSTR(" +Mbj05Car.DCARCD + ", 1, 3) ");
        //sb.append("WHEN '" + DCAR_CD_KABU + "' THEN 1 ");
        //sb.append("ELSE 0 ");
        //sb.append("END AS SUB_SORT_NO, ");
        sb.append(Mbj05Car.SORTNO + ", ");
        sb.append(Tbj18SozaiKanriData.DCARCD + ", ");
        sb.append(Mbj05Car.CARNM + ", ");
        sb.append(Tbj18SozaiKanriData.TITLE + ", ");
        sb.append("MIN(" + Tbj18SozaiKanriData.DATEFROM + ") AS MIN_DATEFROM, ");
        sb.append(Tbj16ContractInfo.CTRTKBN + ", ");
        sb.append(Tbj16ContractInfo.NAMES + ", ");
        sb.append(Tbj16ContractInfo.MUSIC + ", ");
        sb.append(Tbj16ContractInfo.DATEFROM + ", ");
        sb.append(Tbj16ContractInfo.DATETO + " ");

        return sb.toString();
    }

    /**
     * SQLのうちFrom句の部分を作成する.
     *
     * @return SQL
     */
    private String createFromPartOfSql() {
        StringBuilder sb = new StringBuilder();
        sb.append("FROM ");
        sb.append(Tbj18SozaiKanriData.TBNAME + ", ");
        sb.append(Tbj17Content.TBNAME + ", ");
        sb.append(Tbj16ContractInfo.TBNAME + ",");
        sb.append(Mbj05Car.TBNAME + ", ");
        sb.append(Mbj11CarSec.TBNAME + " ");

        return sb.toString();
    }

    /**
     * SQLのうちWhere句の部分を作成する.(1番目のSQL用)
     *
     * @return SQL
     */
    private String createWherePartOfFirstSql() {
        StringBuilder sb = new StringBuilder();
        sb.append("WHERE ");
        sb.append(Mbj05Car.DCARCD + " = " + Mbj11CarSec.DCARCD + " AND ");
        sb.append(Mbj11CarSec.SECTYPE + " = '1' AND ");
        sb.append(Tbj18SozaiKanriData.DATEFROM + " BETWEEN '" + _condition.getDateFrom() + "' AND ");
        sb.append("'" + _condition.getDateTo() + "' AND ");
        sb.append(Tbj18SozaiKanriData.NOKBN + " IN ('" + TBJ18_NOKBN.T.getType() + "','" + TBJ18_NOKBN.S.getType() + "') AND ");
        sb.append(Tbj18SozaiKanriData.STATUS + " = ' ' AND ");
        sb.append(Tbj18SozaiKanriData.CMCD + " = " + Tbj17Content.CMCD + " AND ");
        sb.append(Tbj17Content.CTRTKBN + " = " + Tbj16ContractInfo.CTRTKBN + " AND ");
        sb.append(Tbj17Content.CTRTNO + " = " + Tbj16ContractInfo.CTRTNO + " AND ");
        sb.append(Tbj16ContractInfo.DELFLG + " = ' ' AND ");
        sb.append(Mbj11CarSec.HAMID + " = '" +  _condition.getHamid() + "' AND ");
        sb.append(Mbj11CarSec.AUTHORITY + " > 0 AND ");
        sb.append(Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD + " ");
        String dcarcd = _condition.getDcarcd();
        if (!StringUtil.isBlank(dcarcd)) {
            sb.append("AND '" + dcarcd + "' = SUBSTR(" + Mbj05Car.DCARCD + ",1,3) ");
        }

        return sb.toString();
    }

    /**
     * SQLのうちWhere句の部分を作成する.(2番目のSQL用)
     *
     * @return SQL
     */
    private String createWherePartOfSecondSql() {
        StringBuilder sb = new StringBuilder();
        String dateFrom = _condition.getDateFrom();
        sb.append("WHERE ");
        sb.append(Mbj05Car.DCARCD + " = " + Mbj11CarSec.DCARCD + " AND ");
        sb.append(Mbj11CarSec.SECTYPE + " = '1' AND ");
        sb.append("(('" + dateFrom + "' > " + Tbj18SozaiKanriData.DATEFROM + " AND ");
        sb.append("'" + dateFrom + "' <= " + Tbj18SozaiKanriData.DATETO + ") ");
        sb.append("OR (" + Tbj18SozaiKanriData.DATEFROM + " IS NULL AND '" + dateFrom + "' <= " + Tbj18SozaiKanriData.DATETO + ") ");
        sb.append("OR ('" + dateFrom + "' > " + Tbj18SozaiKanriData.DATEFROM + " AND ");
        sb.append(Tbj18SozaiKanriData.DATETO + " IS NULL)) AND ");
        sb.append(Tbj18SozaiKanriData.NOKBN + " IN ('" + TBJ18_NOKBN.T.getType() + "','" + TBJ18_NOKBN.S.getType() + "') AND ");
        sb.append(Tbj18SozaiKanriData.STATUS + " = ' ' AND ");
        sb.append(Tbj18SozaiKanriData.CMCD + " = " + Tbj17Content.CMCD + " AND ");
        sb.append(Tbj17Content.CTRTKBN + " = " + Tbj16ContractInfo.CTRTKBN + " AND ");
        sb.append(Tbj17Content.CTRTNO + " = " + Tbj16ContractInfo.CTRTNO + " AND ");
        sb.append(Tbj16ContractInfo.DELFLG + " = ' ' AND ");
        sb.append(Mbj11CarSec.HAMID + " = '" +  _condition.getHamid() + "' AND ");
        sb.append(Mbj11CarSec.AUTHORITY + " > 0 AND ");
        sb.append(Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD + " ");
        String dcarcd = _condition.getDcarcd();
        if (!StringUtil.isBlank(dcarcd)) {
            sb.append("AND '" + dcarcd + "' = SUBSTR(" + Mbj05Car.DCARCD + ",1,3) ");
        }

        return sb.toString();
    }

    /**
     * SQLのうちGroup By句の部分を作成する.
     *
     * @return SQL
     */
    private String createGroupByPartOfSql() {
        StringBuilder sb = new StringBuilder();
        sb.append("GROUP BY ");
        sb.append(Mbj05Car.DCARCD + ",");
        sb.append(Mbj05Car.SORTNO + ", ");
        sb.append(Mbj05Car.CARNM + ", ");
        sb.append(Tbj18SozaiKanriData.DCARCD + ", ");
        sb.append(Tbj18SozaiKanriData.TITLE + ", ");
        sb.append(Tbj16ContractInfo.CTRTKBN + ", ");
        sb.append(Tbj16ContractInfo.NAMES + ", ");
        sb.append(Tbj16ContractInfo.MUSIC + ", ");
        sb.append(Tbj16ContractInfo.DATEFROM + ", ");
        sb.append(Tbj16ContractInfo.DATETO + " ");

        return sb.toString();

    }

    /**
     * SQLのうちOrder By句の部分を作成する.
     *
     * @return SQL
     */
    private String createOrderByPartOfSql() {
        StringBuilder sb = new StringBuilder();
        sb.append("ORDER BY ");
        sb.append("SORT_NO, ");
        sb.append(Mbj05Car.SORTNO  + ", ");
        sb.append(Mbj05Car.CARNM + ", ");
        sb.append(Tbj18SozaiKanriData.TITLE + ", ");
        sb.append(Tbj16ContractInfo.CTRTKBN + ", ");
        sb.append(Tbj16ContractInfo.NAMES + ", ");
        sb.append(Tbj16ContractInfo.MUSIC + ", ");
        sb.append(Tbj16ContractInfo.DATEFROM + ", ");
        sb.append(Tbj16ContractInfo.DATETO + " ");

        return sb.toString();

    }
}
