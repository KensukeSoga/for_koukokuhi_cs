package jp.co.isid.ham.media.controller;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.media.model.FindRdTime2AccountBookCondition;
import jp.co.isid.ham.media.model.FindRdTime2AccountBookManager;
import jp.co.isid.ham.media.model.RdTime2AccountBookRegisterManager;
import jp.co.isid.ham.media.model.RdTime2AccountBookRegisterResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * 営業作業台帳ラジオタイムインポート情報登録コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/12 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author S.Fujimoto
 */
public class RegisterRdTime2AccountBookCmd extends Command {

    private static final long serialVersionUID = 1L;

    /** 更新結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** ラジオ番組登録画面登録情報VO */
    private FindRdTime2AccountBookCondition _cond = null;

    /**
     * ラジオ番組登録画面登録情報を登録する
     * @throws HAMException
     */
    @Override
    public void execute() throws HAMException {

        //ラジオタイムインポート情報作成
        List<Tbj02EigyoDaichoVO> tbj02VoList = FindRdTime2AccountBookManager.getInstance().FindRdTime2AccountBook(_cond);
        if (tbj02VoList.size() == 0) {
            getResult().set(RESULT_KEY, new RdTime2AccountBookRegisterResult());
            return;
        }

        //登録処理
        RdTime2AccountBookRegisterManager.getInstance().registerRdTimeInfo2AccountBook(tbj02VoList, _cond);
        getResult().set(RESULT_KEY, new RdTime2AccountBookRegisterResult());
    }

    /**
     * ラジオ番組登録画面登録VOを設定する
     * @param vo RegisterRdProgramInfoVO ラジオ番組登録画面登録VO
     */
    public void setFindRdTime2AccountBookCondition(FindRdTime2AccountBookCondition cond) {
        _cond = cond;
    }

    /**
     * ラジオ番組登録画面登録結果を取得する
     * @return RegisterRdProgramInfoResult 登録結果
     */
    public RdTime2AccountBookRegisterResult getRdTimeImportRegisterResult() {
        return (RdTime2AccountBookRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
