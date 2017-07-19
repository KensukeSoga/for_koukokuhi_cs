package jp.co.isid.ham.model;

import java.io.Serializable;
import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.Date;

import jp.co.isid.nj.integ.sql.AbstractDBModel;
import jp.co.isid.nj.integ.sql.DBModelInterface;
import jp.co.isid.nj.model.DummyNull;


/**
 * <P>
 * HAM用のＤＢモデルクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/04/20 )<BR>
 * </P>
 * @author
 */
public class HAMOracleModel extends AbstractDBModel implements Serializable {

    /**
     *
     */
    private static final long serialVersionUID = -6449040851837707363L;

    //インスタンス保持
    private static HAMOracleModel sqlOracleModel = null;

    /**
     * コンストラクタ
     */
    private HAMOracleModel() {
    }

    /**
     * インスタンス取得
     * @return DBModelInterface このクラスが保持しているインスタンス
     */
    public static synchronized DBModelInterface getInstance() {
        if (sqlOracleModel == null) {
            sqlOracleModel = new HAMOracleModel();
        }

        return sqlOracleModel;
    }

    /**
     *   MS932の変換が必要かどうか
     */
    public boolean needConvertMS932() {
        return false;
    }

    /**
     *   システム日付用のSQL文字列("getdate()")を返します
     */
    public String getSystemDateString() {
        return "SYSDATE";
    }

    /**
     *   日付型用のSQL文字列を返します
     */
    public String getDateString(Date date) {
//    	SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMddHHmmss");
//
//        return " '" + sdf.format(date) + "'";
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
        return "TO_DATE('" + sdf.format(date) + "','YYYY/MM/DD HH24:MI:SS')";
    }

    /**
     *   Timestamp型用のSQL文字列を返します
     */
    public String getTimestampString(Timestamp ts) {
        return "  '" + ts.toString() + "'";
    }

    /**
     * ＳＱＬ文に合わせた文字列に変換します
     *
     * @param obj 変換対象
     * @return ＳＱＬ文字列
     */
    @Override
    public String ConvertToDBString(Object obj) {
        if (obj != null) {
            if (obj.getClass().getName().equals("java.lang.String")) {
                String str = (String)obj;
                if (str.equals("")) {
                    // 親クラス（フレームワーク）のメソッドで
                    // 「''(空文字)」を「' '(空白１つ)」に変換してしまうので、
                    // NULL(DummyNull)に置き換えておく
                    // （Oracle では、空文字＝NULL と認識されている）
                    obj = DummyNull.getInstance();
                }
            }
        }
        // 後は親クラスにお任せ
        return super.ConvertToDBString(obj);
    }

}