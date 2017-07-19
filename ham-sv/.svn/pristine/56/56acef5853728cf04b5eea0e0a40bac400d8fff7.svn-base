package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.JasracManager;
import jp.co.isid.ham.production.model.RegistJasracResult;
import jp.co.isid.ham.production.model.RegistJasracVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

public class RegistJasracCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 登録データ */
    private RegistJasracVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        JasracManager manager = JasracManager.getInstance();
        RegistJasracResult result = new RegistJasracResult();
        manager.registJasrac(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 登録データを設定します
     *
     * @param vo 登録データ
     */
    public void setRegistVO(RegistJasracVO vo)
    {
        _vo = vo;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public RegistJasracResult getRegistResult()
    {
        return (RegistJasracResult) super.getResult().get(RESULT_KEY);
    }

}
