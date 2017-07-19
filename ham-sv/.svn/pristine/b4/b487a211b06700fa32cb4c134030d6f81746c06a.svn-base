package jp.co.isid.ham.menu.model;

import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj31InformationVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * メインメニュー表示データ
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/7 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMainMenuResult extends AbstractServiceResult {

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _dc;

    /** インフォメーションマスタ */
    private List<Mbj31InformationVO> _info;

    /** ログイン情報 */
    private List<LoginVO> _login;

    /** CR制作費管理(受注No未入力) */
    private List<NoInputOrderNoVo> _noInputOrderNo;

    /** CR制作費管理(変更データ) */
    private List<UpdatedCrVO> _updatedCr;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;


    /**
     * 画面項目表示列制御マスタを取得する
     *
     * @return 画面項目表示列制御マスタ
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * 画面項目表示列制御マスタを設定する
     *
     * @param dc 画面項目表示列制御マスタ
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }

    /**
     * インフォメーションマスタを取得する
     *
     * @return インフォメーションマスタ
     */
    public List<Mbj31InformationVO> getInfo() {
        return _info;
    }

    /**
     * インフォメーションマスタを設定する
     *
     * @param info インフォメーションマスタ
     */
    public void setInfo(List<Mbj31InformationVO> info) {
        _info = info;
    }

    /**
     * ログイン情報を取得する
     *
     * @return ログイン情報
     */
    public List<LoginVO> getLogin() {
        return _login;
    }

    /**
     * ログイン情報を設定する
     *
     * @param login ログイン情報
     */
    public void setLogin(List<LoginVO> login) {
        _login = login;
    }

    /**
     * CR制作費管理(受注No未入力)を取得する
     *
     * @return CR制作費管理(受注No未入力)
     */
    public List<NoInputOrderNoVo> getNoInputOrderNo() {
        return _noInputOrderNo;
    }

    /**
     * CR制作費管理(受注No未入力)を設定する
     *
     * @param noInputOrderNo CR制作費管理(受注No未入力)
     */
    public void setNoInputOrderNo(List<NoInputOrderNoVo> noInputOrderNo) {
        _noInputOrderNo = noInputOrderNo;
    }

    /**
     * CR制作費管理(更新データ)を取得する
     *
     * @return CR制作費管理(更新データ)
     */
    public List<UpdatedCrVO> getUpdatedCr() {
        return _updatedCr;
    }

    /**
     * CR制作費管理(更新データ)を設定する
     *
     * @param updatedCr CR制作費管理(更新データ)
     */
    public void setUpdatedCr(List<UpdatedCrVO> updatedCr) {
        _updatedCr = updatedCr;
    }

    /**
     * 機能制御InfoVOリストを取得する
     * @return 機能制御InfoVOリスト
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _funcinfo;
    }

    /**
     * 機能制御InfoVOリストを設定する
     * @param secinfo 機能制御InfoVOリスト
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> funcinfo) {
        _funcinfo = funcinfo;
    }
}
